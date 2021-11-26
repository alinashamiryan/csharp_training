using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddresbookTests
{
    public class ContactTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareGroupsUi_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<ContactDate> fromUI = app.Contacts.GetContactsList();
                List<ContactDate> fromDB = ContactDate.GetAll();
                fromUI.Sort();
                fromDB.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }

        }
    }
}
