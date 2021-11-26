using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddresbookTests
{
   public class ContactHelper : HelperBase
    {
        public ContactHelper (ApplicationManager manager) : base(manager) { }

        public bool acceptNextAlert = true;

        public ContactHelper Create(ContactDate contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnHomePage();
            return this;
        }
        public ContactHelper Modify(int index, ContactDate contact)
        {
            InitContactModification(index);
            FillContactForm(contact);
            SubmitContactModification();
            ReturnHomePage();
            return this;
        }

        public ContactHelper Modify(ContactDate oldData, ContactDate contact)
        {
            InitContactModification(oldData.Id);
            FillContactForm(contact);
            SubmitContactModification();
            ReturnHomePage();
            return this;
        }
        public ContactHelper Remove (int index)
        {
            SelectContact(index);
            RemoveContact();
            return this;
        }
        public ContactHelper Remove(ContactDate toBeRemoved)
        {
            SelectContact(toBeRemoved.Id);
            RemoveContact();
            return this;
        }
        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
     
        public ContactHelper FillContactForm(ContactDate contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("middlename"), contact.Middlename);
            return this;
        }
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            contactCashe = null;
            return this;
        }
        public ContactHelper ReturnHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
        public bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//tbody/tr[@name='entry']["+(index+1)+"]/td/input[@name='selected[]']")).Click();
            return this;
        }
        public ContactHelper SelectContact(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
            return this;
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            driver.FindElement(By.CssSelector("div.msgbox"));
            contactCashe = null;
            return this;
        }
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCashe = null;
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("//tbody/tr[@name='entry'][" + (index+1) + "]" +
                    "//img[@alt='Edit']")).Click();
            return this;
        }
        public ContactHelper InitContactModification(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "']/../.." +
                      "//img[@alt='Edit'])")).Click();
            return this;
        }

        public bool IsContactIn()
        {
            return IsElementPresent(By.XPath("//tr[@name='entry']"));
        }

        private List<ContactDate> contactCashe = null;
        public List<ContactDate> GetContactsList()
        {
                if ( driver.Url != "http://localhost/addressbook")
                {
                driver.Navigate().GoToUrl("http://localhost/addressbook");
                }

            if (contactCashe == null)
            {
                contactCashe = new List<ContactDate>();

                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));
                foreach (IWebElement element in elements)
                {
                    var names = element.Text.Split(' ').ToArray();
                    if (names.Length >= 2)
                    {
                        contactCashe.Add(new ContactDate(names[1], names[0])
                        {
                            Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                        });
                    }
                    else if (names.Length == 1)
                    {
                        contactCashe.Add(new ContactDate(names[0], "")
                        {
                            Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                        });
                    }
                    else
                    {
                        contactCashe.Add(new ContactDate("", "")
                        {
                            Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                        });
                    }
                }
            }
            return new List<ContactDate>(contactCashe);
        }
        public ContactDate GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastname = cells[1].Text;
            string firstname = cells[2].Text;
            string address = cells[3].Text;
            string allEmail = cells[4].Text;
            string allPhones = cells[5].Text;
            return new ContactDate(firstname, lastname)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmail=allEmail
            };
        }

        public ContactDate GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            InitContactModification(index);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");

            string aday = driver.FindElement(By.Name("aday"))
                .FindElement(By.CssSelector("option[selected='selected']")).GetAttribute("value");
            string amonth = driver.FindElement(By.Name("amonth"))
                .FindElement(By.CssSelector("option[selected='selected']")).Text;
            string ayear = driver.FindElement(By.Name("ayear")).GetAttribute("value");

            string bday = driver.FindElement(By.Name("bday"))
                .FindElement(By.CssSelector("option[selected='selected']")).GetAttribute("value");
            string bmonth = driver.FindElement(By.Name("bmonth"))
                .FindElement(By.CssSelector("option[selected='selected']")).Text;
            string byear = driver.FindElement(By.Name("byear")).GetAttribute("value");


            return new ContactDate(firstname, lastname)
            {
                Middlename = middlename,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Nickname= nickname,
                Company = company,
                Title= title,
                Address2= address2,
                Fax=fax,
                Homepage=homepage,
                Phone2=phone2,
                Notes=notes,
                Email =email,
                Email2=email2,
                Email3=email3,
                ADay=aday,
                AMonth=amonth,
                AYear=ayear,
                BDay=bday,
                BMonth=bmonth,
                BYear=byear     
            };
        }

        public string GetContactInformationJoinViewForm(ContactDate contact)
        {
            string joinForm = "";
            if (!string.IsNullOrEmpty (contact.Firstname)  || !string.IsNullOrEmpty(contact.Middlename)  || !string.IsNullOrEmpty(contact.Middlename) )
            {
                joinForm += contact.Firstname + " " + contact.Middlename + " " + contact.Lastname;
            }
            if (!string.IsNullOrEmpty(contact.Nickname))
            {
                joinForm += "\r\n" + contact.Nickname;
            }
            if (!string.IsNullOrEmpty(contact.Title))
            {
                joinForm += "\r\n" + contact.Title;
            }
            if (!string.IsNullOrEmpty(contact.Company))
            {
                joinForm += "\r\n" + contact.Company;
            }
            if (!string.IsNullOrEmpty(contact.Address))
            {
                joinForm += "\r\n" + contact.Address;
            }
            if (!string.IsNullOrEmpty(contact.HomePhone))
            {
                joinForm += "\r\n\r\n" + "H: " + contact.HomePhone;
            }
            if (!string.IsNullOrEmpty(contact.MobilePhone))
            {
                joinForm += "\r\n" + "M: " + contact.MobilePhone.Trim();
            }
            if (!string.IsNullOrEmpty(contact.WorkPhone))
            {
                joinForm += "\r\n" + "W: " + contact.WorkPhone;
            }
            if (!string.IsNullOrEmpty(contact.Fax))
            {
                joinForm += "\r\n" + "F: " + contact.Fax;
            }
            if (!string.IsNullOrEmpty(contact.Email))
            {
                joinForm += "\r\n\r\n" + contact.Email;
            }
            if (!string.IsNullOrEmpty(contact.Email2))
            {
                joinForm += "\r\n" + contact.Email2;
            }
            if (!string.IsNullOrEmpty(contact.Email3))
            {
                joinForm += "\r\n" + contact.Email3;
            }
            if (!string.IsNullOrEmpty(contact.Homepage))
            {
                joinForm += "\r\n" + "Homepage:" + "\r\n" + contact.Homepage;
            }
            if(contact.BDay != "0"||contact.BMonth != "-" || !string.IsNullOrEmpty(contact.BYear))
            {
                joinForm += "\r\n\r\n" + "Birthday " + (contact.BDay=="0"?"":contact.BDay + ". ") + (contact.BMonth=="-"?"":contact.BMonth + " ") + contact.BYear;
            }
            if (contact.ADay != "0" || contact.AMonth != "-" || !string.IsNullOrEmpty(contact.AYear))
            {
                joinForm += "\r\n" + "Anniversary " + (contact.ADay == "0" ? "" : contact.ADay + ". ") + (contact.AMonth == "-" ? "" : contact.AMonth + " ") + contact.AYear;
            }
            if(!string.IsNullOrEmpty(contact.Address2))
            {
                joinForm += "\r\n\r\n" + contact.Address2;
            }
            if (!string.IsNullOrEmpty(contact.Phone2))
            {
                joinForm += "\r\n\r\n" + "P: " + contact.Phone2;
            }
            if (!string.IsNullOrEmpty(contact.Notes))
            {
                joinForm += "\r\n\r\n" + contact.Notes;
            }
            Regex r = new Regex("[ ]+");

            return r.Replace(joinForm.Trim(), @" ");
        }


        public string GetContactInformationFromViewForm(int index)
        {
            manager.Navigator.OpenHomePage();
            InitContactViewDetailed(index);
            string text = driver.FindElement(By.CssSelector("div#content")).Text;
            return text;
        }

        public void InitContactViewDetailed(int index)
        {
            driver.FindElement(By.XPath("//tbody/tr[@name='entry'][" + (index + 1) + "]" +
                    "//img[@alt='Details']")).Click();
        }

        public int GetNumberOfSearchResults()
        {
            string text = driver.FindElement(By.CssSelector("span#search_count")).Text;
            return Int32.Parse(text);
        }
        public int GetNumberTableCount(string filtr)
        {
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));
            int count = 0;
            foreach (IWebElement element in elements)
            {
              var data=  Regex.Match(element.Text, filtr);
                if (data.Success)
                {
                    count++;
                }
            }
            return count;
        }
        public void ContactsFiltr(string filtr)
        {
            manager.Navigator.OpenHomePage();
            driver.FindElement(By.Name("searchstring")).SendKeys(filtr);
            driver.FindElement(By.Name("searchstring")).SendKeys(Keys.Enter);
        }
    }
}
