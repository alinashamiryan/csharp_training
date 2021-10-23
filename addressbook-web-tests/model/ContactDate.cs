using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddresbookTests
{
   public class ContactDate
    {
        private string firstname;
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        private string lastname;
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }
        public ContactDate (string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

    }
}
