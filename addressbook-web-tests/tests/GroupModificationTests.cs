using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddresbookTests
{
    [TestFixture]
   public class GroupModificationTests: TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupDate newDate = new GroupDate("new");
            newDate.Footer = "miu";
            newDate.Header = "miau";

            app.Groups.Modify(1, newDate);
        }
    }
}
