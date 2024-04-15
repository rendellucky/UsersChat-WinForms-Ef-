using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WfChatUsers
{
    public class Contact
    {
        public string Name { get; set; } = null!;

        public override string ToString()
        {
            return Name;
        }

    }
}
