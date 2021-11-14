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
        public static IEnumerable<ContactDate> RandomContactDateProvider()
        {
            List<ContactDate> contact = new List<ContactDate>();
            for (int i = 0; i < 5; i++)
            {
                contact.Add(new ContactDate(GenerateRandomString(20), GenerateRandomString(20))
                {
                    Middlename = GenerateRandomString(15)
                });
            }
                return contact;
        }

        [Test, TestCaseSource("RandomContactDateProvider")]
        public void ContactCreationTest(ContactDate contact)
        {
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
