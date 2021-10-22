using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddresbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        
        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountDate( "admin","secret"));
            GoToGroupsPage();
            InitGroupCreation();
            GroupDate group = new GroupDate("новая");
            group.Footer = "super";
            group.Header = "puper";
            FillGroupForm(group);

            SubmitGroupCreatin();
            ReturnToGroupsPage();
        }

     
    }
}
