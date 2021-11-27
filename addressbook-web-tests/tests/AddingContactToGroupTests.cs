using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddresbookTests
{
   public class AddingContactToGroupTests: AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            GroupDate group = GroupDate.GetAll()[0];
            List<ContactDate> oldList = group.GetContacts();
            ContactDate contact = ContactDate.GetAll().Except(oldList).First();

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactDate> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }

    }
}
