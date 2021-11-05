using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddresbookTests
{
   public class GroupDate : IEquatable <GroupDate>, IComparable <GroupDate>
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        private string header = "";

        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                header = value;
            }
        }

        private string footer = "";
        public string Footer
        {
            get
            {
                return footer;
            }
            set
            {
                footer = value;
            }
        }


        public GroupDate(string name)
        {
            this.name = name;
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
    }
    
}
