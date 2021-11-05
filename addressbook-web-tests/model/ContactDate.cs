using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddresbookTests
{
   public class ContactDate : IEquatable<ContactDate>, IComparable<ContactDate>
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Middlename { get; set; }
        public string Id { get; set; }

        public ContactDate (string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public bool Equals(ContactDate other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname==other.Lastname;
        }
        public override int GetHashCode()
        {
            return (Firstname+Lastname).GetHashCode();
        }

        public int CompareTo(ContactDate other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lastname.CompareTo(other.Lastname) == 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            else
            {
                return Lastname.CompareTo(other.Lastname);
            }
           
        }
    }
}
