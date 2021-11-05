using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddresbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            if (!app.Contacts.IsContactIn())
            {
                ContactDate contact = new ContactDate("Alina", "");
                contact.Middlename = "";
                app.Contacts.Create(contact);
            }
            List<ContactDate> oldContact = app.Contacts.GetContactsList();
            app.Contacts.Remove(0);
            List<ContactDate> newContact = app.Contacts.GetContactsList();
            oldContact.RemoveAt(0);
            Assert.AreEqual(oldContact, newContact);
        }
    }
}

