using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
            app.Contacts.Create(contact);
        }
    }
}
