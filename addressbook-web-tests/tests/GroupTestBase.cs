using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddresbookTests
{
    public class GroupTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareGroupsUi_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<GroupDate> fromUI = app.Groups.GetGroupList();
                List<GroupDate> fromDB = GroupDate.GetAll();
                fromUI.Sort();
                fromDB.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }
            
        }
    }
}
