using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
            app.Groups.Remove(1);

        }
    }
}
