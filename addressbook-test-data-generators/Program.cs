using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Serialization;
using Excel = Microsoft.Office.Interop.Excel;
using WebAddresbookTests;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string typedata = args[0];
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];
            if (typedata == "groups")
            {
                List<GroupDate> groups = new List<GroupDate>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupDate(TestBase.GenerateRandomString(20))
                    {
                        Header = TestBase.GenerateRandomString(25),
                        Footer = TestBase.GenerateRandomString(25)
                    });
                }
                if (format == "excel")
                {
                    writeGroupsToExcelFile(groups, filename);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(filename);            
                    if (format == "csv")
                    {
                        writeGroupsToCsvFile(groups, writer);
                    }
                    else if (format == "xml")
                    {
                        writeGroupsToXmlFile(groups, writer);
                    }
                    else if (format == "json")
                    {
                        writeGroupsToJsonFile(groups, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Unrecognized format" + format);
                    }
                    writer.Close();
                }
                
            }
            else if(typedata == "contacts")
            {
                StreamWriter writer = new StreamWriter(filename);
                List<ContactDate> contacts = new List<ContactDate>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactDate(TestBase.GenerateRandomString(10), 
                        TestBase.GenerateRandomString(15))
                    {
                        Middlename = TestBase.GenerateRandomString(20),
                    });
                }
                if (format == "xml")
                {
                    writeContactsToXmlFile(contacts, writer);
                }
                else if (format == "json")
                {
                    writeContactsToJsonFile(contacts, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format" + format);
                }
                writer.Close();
            }

            
        }
        static void writeGroupsToCsvFile(List<GroupDate> groups, StreamWriter writer)
        {
            foreach(GroupDate group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name,group.Header,group.Footer));
            }
        }

        static void writeGroupsToXmlFile(List<GroupDate> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupDate>)).Serialize(writer, groups);
        }
        static void writeGroupsToJsonFile(List<GroupDate> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups));
        }
        static void writeGroupsToExcelFile(List<GroupDate> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;

            int row = 1;
            foreach(GroupDate group in groups)
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);
            wb.Close();
            app.Quit();
            app.Visible = false;
        }



        static void writeContactsToXmlFile(List<ContactDate> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactDate>)).Serialize(writer, contacts);
        }
        static void writeContactsToJsonFile(List<ContactDate> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts));
        }

    }
}
