using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddresbookTests
{
    [TestFixture]
    class ContactsSearch : AuthTestBase
    {
        [Test]
        public void ContactSearch()
        {
            List<ContactDate> contacts = app.Contacts.GetContactsList();
            if (app.Contacts.GetContactsList().Count < 2)
            {
                ContactDate contact = new ContactDate("Alina", "fff");
                contact.Middlename = "";
                app.Contacts.Create(contact);
                ContactDate contact2 = new ContactDate("Alina", "zzz");
                contact.Middlename = "";
                app.Contacts.Create(contact2);
            }
            string f = "fff";
            app.Contacts.ContactsFiltr(f);
            int count = app.Contacts.GetNumberOfSearchResults();
            int filtr = app.Contacts.GetNumberTableCount(f);
            Assert.AreEqual(count, filtr);
        }
    }
}
