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
        public string Address { get; set; }
        public string WorkPhone { get; set; }

        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }

        private string allPhones;
        public string AllPhones { 
            get {
                if (allPhones!=null) {
                    return allPhones;
                }
                else
                {
                    return CleanUP(HomePhone) + CleanUP(MobilePhone) + CleanUP(WorkPhone).Trim();
                }
            } 
            set {
                allPhones = value;
            } }
        private string allEmail;
        public string AllEmail
        {
            get
            {
                if (allEmail != null)
                {
                    return allEmail;
                }
                else
                {
                    return CleanUP2(Email) + CleanUP2(Email2) + CleanUP2(Email3).Trim();
                }
            }
            set
            {
                allEmail = value;
            }
        }


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
        private string CleanUP(string phone)
        {
            if (phone == null|| phone=="")
            {
                return "";
            }
            else
            {
                return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "")+"\r\n";
            }
        }
        private string CleanUP2(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            else
            {
                return email + "\r\n";
            }
        }
    }
}
