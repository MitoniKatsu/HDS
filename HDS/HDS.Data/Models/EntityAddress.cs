using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Data.Models
{
    public class EntityAddress
    {
        public int EntityAddressID { get; set; }
        public int EntityID { get; set; }
        public int AddressID { get; set; }
        public int AddressTypeID { get; set; }
        public bool Primary { get; set; }
        public Address Address { get; set; }
        public AddressType AddressType { get; set; }
    }
}
