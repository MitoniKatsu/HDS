using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.DTOs
{
    public class ContactMethodTypeDto
    {
        public int ContactMethodTypeID { get; set; }
        public string ContactMethodTypeName { get; set; }
    }

    public class ContactMethodTypeDetailsDto
    {
        public string ContactMethodTypeName { get; set; }
    }
}
