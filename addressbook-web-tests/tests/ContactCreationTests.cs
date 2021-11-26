using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;

namespace WebAddresbookTests
{
    [TestFixture]
    public class ContactCreationTests : ContactTestBase
    {
        public static IEnumerable<ContactDate> RandomContactDateProvider()
        {
            List<ContactDate> contact = new List<ContactDate>();
            for (int i = 0; i < 5; i++)
            {
                contact.Add(new ContactDate(GenerateRandomString(20), GenerateRandomString(20))
                {
                    Middlename = GenerateRandomString(15)
                });
            }
                return contact;
        }

        public static IEnumerable<ContactDate> ContactDataFromXmlFile()
        {
            return (List<ContactDate>)
                new XmlSerializer(typeof(List<ContactDate>)).
                Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactDate> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactDate>>
                (File.ReadAllText(@"contacts.json"));
        }

        [Test, TestCaseSource("ContactDataFromXmlFile")]
        public void ContactCreationTest(ContactDate contact)
        {
            List<ContactDate> oldContact = ContactDate.GetAll();
            app.Contacts.Create(contact);
            List<ContactDate> newContact = ContactDate.GetAll();
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }
    }
}
