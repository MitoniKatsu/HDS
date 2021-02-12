using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.Models
{
    public class ContactMethod
    {
        public int ContactMethodID { get; set; }
        public int EntityID { get; set; }
        public int ContactMethodTypeID { get; set; }
        public string ContactMethodValue { get; set; }
        public ContactMethodType ContactMethodType { get; set; }
    }
}
