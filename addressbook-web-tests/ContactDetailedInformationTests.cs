using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddresbookTests
{
    [TestFixture]
    class ContactDetailedInformationTests : AuthTestBase
    {
        [Test]
        public void ContactDetailedInformationTest()
        {
            string fromView = app.Contacts.GetContactInformationFromViewForm(0);
            ContactDate fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            string joinForm = app.Contacts.GetContactInformationJoinViewForm (fromForm);
            Assert.AreEqual(fromView, joinForm);
        }
    }
}
