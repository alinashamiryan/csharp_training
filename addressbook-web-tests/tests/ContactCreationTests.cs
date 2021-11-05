using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddresbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactDate contact = new ContactDate("Alina", "Shamiryan");
            contact.Middlename = "Alexandrovna";

            List<ContactDate> oldContact = app.Contacts.GetContactsList();
            app.Contacts.Create(contact);
            List<ContactDate> newContact = app.Contacts.GetContactsList();
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }
    }
}
