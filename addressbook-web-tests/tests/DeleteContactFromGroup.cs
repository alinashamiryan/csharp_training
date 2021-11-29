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
            if (groups.Count==0)
            {
                GroupDate group = new GroupDate("новая");
                group.Footer = "super";
                group.Header = "puper";
                app.Groups.Create(group);
                groups = GroupDate.GetAll();
            }

            List<ContactDate> con = ContactDate.GetAll();
            if (con.Count == 0)
            {
                ContactDate contact = new ContactDate("Alina", "");
                contact.Middlename = "";
                app.Contacts.Create(contact);
                app.Contacts.AddContactToGroup(ContactDate.GetAll().First(), groups.First());

            }
            for (int i = 0; i < groups.Count; i++)
            {
               ContactDate contact = groups[i].GetContacts().FirstOrDefault();

                if (contact != null)
                {
                    isOk = true;
                   GroupDate group = groups[i];
                    Delete(contact, group);
                    break; 
                }
            }
            if(!isOk)
            {
                GroupDate group = GroupDate.GetAll()[0];
                ContactDate contact = ContactDate.GetAll().First();
                app.Contacts.AddContactToGroup(contact, group);
                Delete(contact, group);
            }
        }
        public void Delete(ContactDate contact, GroupDate group)
        {
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
