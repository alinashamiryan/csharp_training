using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

            app.Groups.Create(group);
        }


        [Test]
        public void EmptyGroupCreationTest()
        {
        
            GroupDate group = new GroupDate("");
            group.Footer = "";
            group.Header = "";

            app.Groups.Create(group);
        }
    }
}
