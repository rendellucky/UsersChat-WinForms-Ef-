using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WfChatUsers
{
    public class ContactManager
    {
        public List<Contact> Contacts { get; } = new List<Contact>();

        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);
        }

        public void RemoveContact(Contact contact)
        {
            Contacts.Remove(contact);
        }

        public void RenameContact(Contact contact, string newName)
        {
            var existingContact = Contacts.FirstOrDefault(c => c.Name == contact.Name);
            if (existingContact != null)
            {
                existingContact.Name = newName;
            }
        }
    }
}
