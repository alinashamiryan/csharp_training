using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
            app.Contacts.Remove(1);   
        }
    }
}

