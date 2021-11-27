using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAddresbookTests
{
    [Table(Name="group_list")]
   public class GroupDate : IEquatable <GroupDate>, IComparable <GroupDate>
    {
        [Column(Name= "group_name")]
        public string Name { get; set; }

        [Column(Name = "group_header")]
        public string Header { get; set; }

        [Column(Name = "group_footer")]
        public string Footer { get; set; }

        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }
        public GroupDate()
        {
        }
        public GroupDate(string name)
        {
            Name = name;
        }

        public bool Equals(GroupDate other)
        {
         if(Object.ReferenceEquals (other, null))
            {
                return false;
            }
         if(Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public int CompareTo(GroupDate other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        public static List<GroupDate> GetAll()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
               return  (from g in db.Groups select g).ToList();
            }
        }
        public List<ContactDate> GetContacts()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from c in db.Contacts
                        from gcr in db.GCR.Where(p=>p.GroupId==Id && p.ContactId==c.Id && c.Deprecated == "0000-00-00 00:00:00")
                        select c).Distinct().ToList();
            }
        }
    }
    
}
