using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
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
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait=new TimeSpan(0,0,5);
            baseURL = "http://localhost/addressbook";
            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            grouphelper = new GroupHelper(this);
            contacthelper = new ContactHelper(this);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.OpenHomePage();
                app.Value = newInstance;
                
            }
            return app.Value;
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
    }
}
