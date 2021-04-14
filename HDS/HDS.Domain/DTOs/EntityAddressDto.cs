using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.DTOs
{
    public class BaseEntityAddressDto
    {
        public int AddressTypeID { get; set; }
        public bool? Primary { get; set; }
    }

    public class EntityAddressDto : BaseEntityAddressDto
    {
        public int EntityAddressID { get; set; }
        public int EntityID { get; set; }
        
        public int AddressID { get; set; }
        public AddressDto Address { get; set; }
        public AddressTypeDto AddressType { get; set; }
    }

    public class CustomerAddressDto : EntityAddressDto
    {
        public int CustomerID { get; set; }
    }

    public class EmployeeAddressDto : EntityAddressDto
    {
        public int EmployeeID { get; set; }
    }

    public class StoreAddressDto : EntityAddressDto
    {
        public int StoreID { get; set; }
    }

    public class CreateEntityAddressDto : BaseEntityAddressDto
    {
        public CreateAddressDto Address { get; set; }
    }

    public class CreateCustomerAddressDto : CreateEntityAddressDto
    {
    }

    public class CreateEmployeeAddressDto : CreateEntityAddressDto
    {
    }

    public class CreateStoreAddressDto : CreateEntityAddressDto
    {
    }
}
