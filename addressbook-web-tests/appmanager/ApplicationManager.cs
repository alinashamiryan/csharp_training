using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddresbookTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
    
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper grouphelper;
        protected ContactHelper contacthelper;

        public ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";
            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            grouphelper = new GroupHelper(this);
            contacthelper = new ContactHelper(this);
        }

        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }
        public NavigationHelper Navigator
        {
            get
            {
                return navigator;
            }
        }
        public GroupHelper Groups
        {
            get
            {
                return grouphelper;
            }
        }
        public ContactHelper Contacts
        {
            get
            {
                return contacthelper;
            }
        }
        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
         
        }
    }
}
