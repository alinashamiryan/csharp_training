using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using NUnit.Framework;


namespace WebAddresbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        public static IEnumerable<GroupDate> RandomGroupDateProvider()
        {
            List<GroupDate> groups = new List<GroupDate>();
            for(int i=0; i<5; i++)
            {
                groups.Add(new GroupDate(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }

        public static IEnumerable<GroupDate> GroupDataFromCsvFile()
        {
            List<GroupDate> groups = new List<GroupDate>();
            string [] lines = File.ReadAllLines(@"groups.csv",Encoding.Default);
            foreach (string l in lines)
            {
                string [] parts = l.Split(',');
                groups.Add(new GroupDate(parts[0])
                {
                    Header=parts[1],
                    Footer=parts[2]
                });
            }
            return groups;
        }

        public static IEnumerable<GroupDate> GroupDataFromXmlFile()
        { 
            return (List<GroupDate>)
                new XmlSerializer(typeof(List<GroupDate>)).
                Deserialize(new StreamReader(@"groups.xml"));
        }

        public static IEnumerable<GroupDate> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupDate>>
                (File.ReadAllText(@"groups.json"));
        }
        public static IEnumerable<GroupDate> GroupDataFromExcelFile()
        {
            List<GroupDate> groups = new List<GroupDate>();
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"groups.xlsx"));
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;

            for(int i=1; i<=range.Rows.Count; i++)
            {
                groups.Add(new GroupDate()
                {
                    Name = range.Cells[i, 1].Value,
                    Header = range.Cells[i, 2].Value,
                    Footer = range.Cells[i, 3].Value
                });
            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return groups;
        }


        [Test, TestCaseSource("GroupDataFromXmlFile")]
        public void GroupCreationTest(GroupDate group)
        {
            List<GroupDate> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            List<GroupDate> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
