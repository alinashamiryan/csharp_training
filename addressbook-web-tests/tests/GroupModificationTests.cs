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

            app.Groups.Modify(1, newDate);
        }
    }
}
