using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Sever
{
    internal class Program
    {
        static TcpListener tcpListener;
        static List<TcpClient> clients = new List<TcpClient>();
        static Dictionary<TcpClient, string> clientUsernames = new Dictionary<TcpClient, string>();

        public static async Task Main(string[] args)
        {
            tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 7575);
            tcpListener.Start();

            await WaitForConnectionAsync();
        }

        static async Task WaitForConnectionAsync()
        {
            while (true)
            {
                try
                {

                    Console.WriteLine("Waiting for client...");
                    var client = await tcpListener.AcceptTcpClientAsync();

                    clients.Add(client);
                    _ = HandleClientAsync(client);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static async Task HandleClientAsync(TcpClient client)
        {

            var stream = client.GetStream();
            var sr = new StreamReader(stream, Encoding.UTF8);
            var sw = new StreamWriter(stream, Encoding.UTF8);

            var login = await sr.ReadLineAsync();
            clientUsernames[client] = login;

            Console.WriteLine($"{login} connected");

            foreach(var c in clients)
            {
                var swClient = new StreamWriter(c.GetStream(), Encoding.UTF8);
                await swClient.WriteLineAsync($"{login} joined the chat");
                await swClient.FlushAsync();
            }
            await sw.FlushAsync();

            try
            {
                while (true)
                {
                    var msg = await sr.ReadLineAsync();

                    await SendMessageAsync($"{clientUsernames[client]}: {msg}", client);
                }
            }
            catch (Exception)
            {
                clients.Remove(client);
                Console.WriteLine($"{clientUsernames[client]} disconnected");
                clientUsernames.Remove(client);

                foreach (var c in clients)
                {
                    var swClient = new StreamWriter(c.GetStream(), Encoding.UTF8);
                    await swClient.WriteLineAsync($"{login} left the chat");
                    await swClient.FlushAsync();
                }
            }
        }

        static async Task SendMessageAsync(string message, TcpClient sender)
        {
            foreach (var client in clients)
            {
                var stream = client.GetStream();
                //byte[] buf = Encoding.UTF8.GetBytes(message);
                //await stream.WriteAsync(buf, 0, buf.Length);
                var sw = new StreamWriter(stream, Encoding.UTF8);
                await sw.WriteLineAsync(message);
                await sw.FlushAsync();
            }
        }
    }
}