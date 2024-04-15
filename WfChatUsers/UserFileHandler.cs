using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WfChatUsers
{
    public class UserFileHandler
    {
        string filePath = "users.json";

        public List<User> LoadUsers()
        {
            List<User> users = new List<User>();
            if(File.Exists(filePath))
            {
                using var sr = new StreamReader(filePath);
                string line;
                while((line = sr.ReadLine()!) != null)
                {
                    string[] parts = line.Split(',');
                    if(parts.Length > 0)
                    {
                        string login = parts[0];
                        string password = parts[1];
                        users.Add(new User { Login = login, Password = password });
                    }
                }
            }
            return users;
        }

        public void SaveUsersToFile(List<User> users)
        {
            using var sw = new StreamWriter(filePath);
            foreach(User user in users)
            {
                sw.WriteLine($"{user.Login},{user.Password}");
            }
        }

        public bool IsUserRegistered(string login, string password)
        {
            List<User> users = LoadUsers();
            foreach(User user in users)
            {
                if(user.Login == login && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
