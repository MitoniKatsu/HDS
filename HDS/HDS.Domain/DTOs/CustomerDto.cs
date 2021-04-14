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
        public IList<CustomerAddressDto> Addresses { get; set; }
        public IList<CustomerContactDto> ContactMethods { get; set; }
        public IList<CustomerQueryOrderDto> Orders { get; set; }
    }

    public class CreateCustomerDto : BaseCustomerDto
    {
        public IList<CreateCustomerAddressDto> Addresses { get; set; }
        public IList<CreateCustomerContactDto> ContactMethods { get; set; }
    }

    public class UpdateCustomerDetailsDto : BaseCustomerDto
    {
        public int CustomerID { get; set; }
    }
}
