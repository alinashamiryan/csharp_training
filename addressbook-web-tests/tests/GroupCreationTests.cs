using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddresbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        
        [Test]
        public void GroupCreationTest()
        {
        
            GroupDate group = new GroupDate("новая");
            group.Footer = "super";
            group.Header = "puper";

            List<GroupDate> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            List<GroupDate> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }


        [Test]
        public void EmptyGroupCreationTest()
        {
        
            GroupDate group = new GroupDate("");
            group.Footer = "";
            group.Header = "";

            List<GroupDate> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            List<GroupDate> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
