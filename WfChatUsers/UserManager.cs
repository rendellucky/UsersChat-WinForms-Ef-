using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WfChatUsers
{
    public class UserManager
    {
        public List<User> Users { get; set; }

        public UserManager()
        {
            Users = new List<User>();
        }
    }
}
