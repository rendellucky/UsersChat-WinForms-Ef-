using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WfChatUsers
{
    public partial class MainForm : Form
    {
        public UserManager UserManager { get; set; }
        private User currentUser;

        public TcpClient tcpClient;

        ContactManager contactManager = new ContactManager();
        public MainForm()
        {
            InitializeComponent();
            UserManager = new UserManager();
            btnSend.Enabled = false;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            UserFileHandler userFileHandler = new UserFileHandler();
            UserManager.Users = userFileHandler.LoadUsers();
            if (UserManager.Users.Count == 0)
            {
                RegistrationForm registrationForm = new RegistrationForm(UserManager);
                if (registrationForm.ShowDialog() == DialogResult.OK)
                {
                    currentUser = registrationForm.AuthenticatedUser;
                    await StartChatAsync(currentUser);
                }
                else
                {
                    Close();
                }
            }
            else
            {
                LoginForm loginForm = new LoginForm(UserManager);
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    currentUser = loginForm.AuthenticatedUser;
                    await StartChatAsync(currentUser);
                }
                else
                {
                    Close();
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async Task StartChatAsync(User currentUser)
        {
            tcpClient = new TcpClient("127.0.0.1", 7575);
            var stream = tcpClient.GetStream();
            var sw = new StreamWriter(stream, Encoding.UTF8);
            await sw.WriteLineAsync(currentUser.Login);
            await sw.FlushAsync();

            _ = ReceiveMessageAsync(stream);
        }

        private async Task ReceiveMessageAsync(NetworkStream stream)
        {
            var sr = new StreamReader(stream, Encoding.UTF8);

            try
            {
                while (true)
                {
                    var msg = await sr.ReadLineAsync();

                    lbChat.Invoke(new Action(() =>
                    {
                        lbChat.Items.Add(msg);
                    }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string msg = tbMessage.Text;
            var stream = tcpClient.GetStream();
            var sw = new StreamWriter(stream, Encoding.UTF8);
            await sw.WriteLineAsync(msg);
            await sw.FlushAsync();
            tbMessage.Clear();
        }

        private void MainForm_TextChanged(object sender, EventArgs e)
        {
            if (tbMessage.Text != "")
                btnSend.Enabled = true;
            else
                btnSend.Enabled = false;
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            var newContact = new Contact { Name = tbNewContact.Text };
            contactManager.AddContact(newContact);
            UpdateContactList();
        }

        private void UpdateContactList()
        {
            lbContacts.Items.Clear();
            lbContacts.Items.AddRange(contactManager.Contacts.ToArray());
        }

        private void btnUpdateContact_Click(object sender, EventArgs e)
        {
            if (lbContacts.SelectedItem is Contact selectedContact)
            {
                contactManager.RenameContact(selectedContact, tbNewContact.Text);
                UpdateContactList();
            }
        }

        private void btnDeleteContact_Click(object sender, EventArgs e)
        {
            if (lbContacts.SelectedItem is Contact selectedContact)
            {
                contactManager.RemoveContact(selectedContact);
                UpdateContactList();
            }
        }
    }
}
