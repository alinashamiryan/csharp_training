using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;

namespace WebAddresbookTests
{
    public class AddressbookDB: LinqToDB.Data.DataConnection
    {
        public AddressbookDB(): base("AddressBook") { }
        public ITable<GroupDate> Groups { get { return GetTable<GroupDate>(); } }
        public ITable<ContactDate> Contacts { get { return GetTable<ContactDate>(); } }
        public ITable<GroupContactRelation> GCR { get { return GetTable<GroupContactRelation>(); } }

    }
}
