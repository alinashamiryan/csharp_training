using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddresbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            if (!app.Contacts.IsContactIn())
            {
                ContactDate con = new ContactDate("Alina", "");
                con.Middlename = "";
                app.Contacts.Create(con);
            }
            ContactDate contact = new ContactDate("kkkkk", "zzzz");
            contact.Middlename = null;
            List<ContactDate> oldContact = ContactDate.GetAll();
            ContactDate oldData = oldContact[0];
            app.Contacts.Modify(oldData, contact);
            List<ContactDate> newContact = ContactDate.GetAll();
            oldContact[0].Firstname = contact.Firstname;
            oldContact[0].Lastname = contact.Lastname;
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);

            foreach (ContactDate cont in newContact)
            {
                if (cont.Id == oldData.Id)
                {
                    Assert.AreEqual(contact.Firstname + contact.Lastname, oldData.Firstname+oldData.Lastname);
            }
        }
        }
    }
}
