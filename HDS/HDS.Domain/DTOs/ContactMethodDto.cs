using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.DTOs
{
    public class BaseContactMethodDto
    {
        public int EntityTypeID { get; set; }
        public int ContactMethodTypeID { get; set; }
        public string ContactMethodValue { get; set; }

    }

    public class ContactMethodDto : BaseContactMethodDto
    {
        public int ContactMethodID { get; set; }
        public int EntityID { get; set; }

        public ContactMethodTypeDto ContactMethodType { get; set; }
    }

    public class CreateContactMethodDto : BaseContactMethodDto
    {

    }
}
