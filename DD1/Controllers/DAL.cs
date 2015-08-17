using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DD1.Models;

namespace DD1.Controllers
{
    public sealed class DAL
    {
        private static DAL instance = null;

        private DAL()
        {
        }

        public static DAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAL();

                    Init();
                }
                return instance;
            }
        }

        private static List<Contact> Contacts;

        public List<Contact> GetContacts()
        {
            return Contacts;
        }

        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);
        }

        public void RemoveContacts()
        {
            Contacts.Clear();
        }

        private static void Init()
        {
            Contacts = new List<Contact>();
        }
    }
}