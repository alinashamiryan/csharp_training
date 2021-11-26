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
   public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base (manager)
        {
        }

        public GroupHelper Create(GroupDate group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Modify(int index, GroupDate newDate)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(index);
            InitGroupModification();
            FillGroupForm(newDate);
            SubmitGroupModification();
            ReturnToGroupsPage();

            return this;
        }

        internal GroupHelper Modify(GroupDate oldData, GroupDate newDate)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(oldData.Id);
            InitGroupModification();
            FillGroupForm(newDate);
            SubmitGroupModification();
            ReturnToGroupsPage();

            return this;
        }

        public GroupHelper Remove(GroupDate group)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(group.Id);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int index)
        {
            manager.Navigator.GoToGroupsPage();

           SelectGroup(index);
           RemoveGroup();
           ReturnToGroupsPage();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper FillGroupForm(GroupDate group)
        {

            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }


        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCashe = null;
            return this;
        }
        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + (index+1) + "]/input")).Click();
            return this;
        }
        public GroupHelper SelectGroup(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='"+id+"'])")).Click();
            return this;
        }
        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[5]")).Click();
            groupCashe = null;
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCashe = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public bool IsGroupIn()
        {
            return IsElementPresent(By.XPath("//div[@id='content']/form/span"));
        }

        private List<GroupDate> groupCashe = null;

        public List<GroupDate> GetGroupList()
        {
            if (groupCashe == null)
            {
                groupCashe = new List<GroupDate>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCashe.Add(new GroupDate(null)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
                string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
               string [] parts = allGroupNames.Split('\n');
                int shift = groupCashe.Count - parts.Length;
                for(int i=0; i<groupCashe.Count; i++)
                {
                    if (i < shift)
                    {
                        groupCashe[i].Name = "";
                    }
                    else
                    {
                        groupCashe[i].Name = parts[i-shift].Trim();
                    }
                    
                }
            }
            return new List<GroupDate>(groupCashe);
        }
    }
}
