using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddresbookTests
{
    [TestFixture]
   public class GroupModificationTests: AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            if (!app.Groups.IsGroupIn())
            {
                GroupDate group = new GroupDate("новая");
                group.Footer = "super";
                group.Header = "puper";
                app.Groups.Create(group);
            }
            GroupDate newDate = new GroupDate("new");
            newDate.Footer = null;
            newDate.Header = null;

            List<GroupDate> oldGroups = app.Groups.GetGroupList();
            GroupDate oldData = oldGroups[0];
            app.Groups.Modify(0, newDate);
            List<GroupDate> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newDate.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupDate group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newDate.Name,oldData.Name);
                }
            }
        }
    }
}
