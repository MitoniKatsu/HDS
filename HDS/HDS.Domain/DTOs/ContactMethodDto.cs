using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.DTOs
{
    public class BaseContactMethodDto
    {
        public int ContactMethodTypeID { get; set; }
        public string ContactMethodValue { get; set; }

    }

    public class ContactMethodDto : BaseContactMethodDto
    {
        public int ContactMethodID { get; set; }
        public int EntityID { get; set; }

        public ContactMethodTypeDto ContactMethodType { get; set; }
    }

    public class CustomerContactDto : ContactMethodDto
    {
        public int CustomerID { get; set; }
    }

    public class EmployeeContactDto : ContactMethodDto
    {
        public int EmployeeID { get; set; }
    }

    public class StoreContactDto : ContactMethodDto
    {
        public int StoreID { get; set; }
    }

    public class CreateContactMethodDto : BaseContactMethodDto
    {
    }

    public class CreateCustomerContactDto : CreateContactMethodDto
    {
    }

    public class CreateEmployeeContactDto : CreateContactMethodDto
    {
    }

    public class CreateStoreContactDto : CreateContactMethodDto
    {
    }
}
