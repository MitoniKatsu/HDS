using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.DTOs
{
    public class BaseEntityAddressDto
    {
        public int EntityTypeID { get; set; }
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
        public EntityTypeDto EntityType { get; set; }
    }

    public class CreateEntityAddressDto : BaseEntityAddressDto
    {
        public CreateAddressDto Address { get; set; }
    }
}
