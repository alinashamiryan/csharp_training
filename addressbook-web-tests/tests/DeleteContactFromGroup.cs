using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddresbookTests
{
    public class DeleteContactFromGroup : AuthTestBase
    {
        [Test]
        public void TestDeleteContactFromGroup()
        {
            List <GroupDate> groups = GroupDate.GetAll();
            bool isOk = false;
            for (int i = 0; i < groups.Count; i++)
            {
               ContactDate contact = groups[i].GetContacts().FirstOrDefault();

                if (contact != null)
                {
                    isOk = true;
                   GroupDate group = groups[i];
                    List<ContactDate> oldList = group.GetContacts();
                    app.Contacts.DeleteContactFromGroup(contact, group);
                    List<ContactDate> newList = group.GetContacts();
                    oldList.Remove(contact);
                    newList.Sort();
                    oldList.Sort();
                    Assert.AreEqual(oldList, newList);
                    break; 
                }
            }
            if(!isOk)
            {
                GroupDate group = GroupDate.GetAll()[0];
                ContactDate contact = ContactDate.GetAll().First();
                app.Contacts.AddContactToGroup(contact, group);
                List<ContactDate> oldList = group.GetContacts();
                app.Contacts.DeleteContactFromGroup(contact, group);
                List<ContactDate> newList = group.GetContacts();
                oldList.Remove(contact);
                newList.Sort();
                oldList.Sort();
                Assert.AreEqual(oldList, newList);
            }
            
            
        }
    }
}
