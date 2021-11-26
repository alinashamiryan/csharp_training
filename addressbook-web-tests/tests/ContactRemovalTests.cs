using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddresbookTests
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
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
            List<ContactDate> oldContact = ContactDate.GetAll();
            ContactDate toBeRemoved = oldContact[0];
            app.Contacts.Remove(toBeRemoved);
            List<ContactDate> newContact = ContactDate.GetAll();
            
            oldContact.RemoveAt(0);
            Assert.AreEqual(oldContact, newContact);

            foreach(ContactDate cont in newContact)
            {
                Assert.AreNotEqual(cont.Id, toBeRemoved.Id);
            }
        }
    }
}

