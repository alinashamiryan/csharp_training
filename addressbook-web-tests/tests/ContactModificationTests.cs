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
            app.Contacts.Modify(1, contact);
        }
    }
}
