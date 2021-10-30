using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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



        public ContactHelper Create()
        {
            InitContactCreation();
            FillContactForm(new ContactDate("Alina", "Shamiryan"));
            SubmitContactCreation();
            ReturnHomePage();
            return this;
        }

        public ContactHelper Modify(int index)
        {
            InitContactModification(index);
            FillContactForm(new ContactDate("Murzik", "Murzilkin"));
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
        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper FillContactForm(ContactDate contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            return this;
        }
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
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
            driver.FindElement(By.XPath("//tbody/tr[@name='entry']["+index+"]/td/input[@name='selected[]']")).Click();
            return this;
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            return this;
        }
        public void SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
        }

        public void InitContactModification(int index)
        {
            driver.FindElement(By.XPath("//tbody/tr[@name='entry'][" + index + "]//img[@alt='Edit']")).Click();
        }
    }
}
