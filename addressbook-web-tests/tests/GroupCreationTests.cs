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
        public static IEnumerable<GroupDate> RandomGroupDateProvider()
        {
            List<GroupDate> groups = new List<GroupDate>();
            for(int i=0; i<5; i++)
            {
                groups.Add(new GroupDate(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }
        

        [Test, TestCaseSource("RandomGroupDateProvider")]
        public void GroupCreationTest(GroupDate group)
        {
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
