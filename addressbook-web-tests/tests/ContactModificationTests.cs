using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddresbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            if (!app.Contacts.IsContactIn())
            {
                ContactDate con = new ContactDate("Alina", "");
                con.Middlename = "";
                app.Contacts.Create(con);
            }
            ContactDate contact = new ContactDate("kkkkk", "zzzz");
            contact.Middlename = null;

            List<ContactDate> oldContact = app.Contacts.GetContactsList();
            app.Contacts.Modify(0, contact);
            List<ContactDate> newContact = app.Contacts.GetContactsList();
            oldContact[0].Firstname = contact.Firstname;
            oldContact[0].Lastname = contact.Lastname;
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);

        }
    }
}
