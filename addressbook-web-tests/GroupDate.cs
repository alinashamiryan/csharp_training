using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddresbookTests
{
   public class GroupDate
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
    }
    
}
