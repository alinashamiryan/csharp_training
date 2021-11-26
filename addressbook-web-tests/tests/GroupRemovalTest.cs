using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddresbookTests
{
    [TestFixture]
    public class GroupRemovalTests: GroupTestBase
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
            List<GroupDate> oldGroups = GroupDate.GetAll();
            GroupDate toBeRemoved = oldGroups[0];
            app.Groups.Remove(toBeRemoved); 
            List<GroupDate> newGroups = GroupDate.GetAll();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach(GroupDate group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
