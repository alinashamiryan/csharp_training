﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddresbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountDate("admin", "secret"));
            InitContactCreation();
            FillContactForm(new ContactDate("Alina","Shamiryan"));
            SubmitContactCreation();
            ReturnHomePage();
        }
    }
}
