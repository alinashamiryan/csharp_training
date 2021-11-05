using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddresbookTests
{
    [TestFixture]
    public class GroupRemovalTests: AuthTestBase
    {
    

        [Test]
        public void GroupRemovalTest()
        {
            if (!app.Groups.IsGroupIn())
            {
                GroupDate group = new GroupDate("новая");
                group.Footer = "super";
                group.Header = "puper";
                app.Groups.Create(group);
            }
            List<GroupDate> oldGroups = app.Groups.GetGroupList();
            app.Groups.Remove(0);
            List<GroupDate> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
