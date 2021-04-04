using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.DTOs
{
    public class BaseCustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class CustomerDto : BaseCustomerDto
    {
        public int CustomerID { get; set; }
        public IList<EntityAddressDto> Addresses { get; set; }
        public IList<ContactMethodDto> ContactMethods { get; set; }
        public IList<CustomerQueryOrderDto> Orders { get; set; }
    }

    public class CreateCustomerDto : BaseCustomerDto
    {
        public IList<CreateEntityAddressDto> Addresses { get; set; }
        //public IList<CreateContactMethodDto> ContactMethods { get; set; }
    }
}
