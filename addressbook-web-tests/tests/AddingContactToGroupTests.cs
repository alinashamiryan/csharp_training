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
            List<GroupDate> groups = GroupDate.GetAll();
            if (groups.Count == 0)
            {
                GroupDate gr = new GroupDate("новая");
                gr.Footer = "super";
                gr.Header = "puper";
                app.Groups.Create(gr);
            }

            List<ContactDate> con = ContactDate.GetAll();
            if (con.Count == 0)
            {
                ContactDate cont = new ContactDate("Alina", "");
                cont.Middlename = "";
                app.Contacts.Create(cont);

            }


            GroupDate group = GroupDate.GetAll()[0];
            List<ContactDate> oldList = group.GetContacts();
            ContactDate contact = ContactDate.GetAll().Except(oldList).FirstOrDefault();
            if (contact == null)
            {
                ContactDate cont = new ContactDate("Пупсик", "");
                cont.Middlename = "";
                app.Contacts.Create(cont);
                contact = ContactDate.GetAll().Except(oldList).FirstOrDefault();
            }


            app.Contacts.AddContactToGroup(contact, group);

            List<ContactDate> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }

    }
}
