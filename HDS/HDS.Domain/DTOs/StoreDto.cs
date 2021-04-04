using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.DTOs
{
    public class StoreDto
    {
        public int StoreID { get; set; }
        public string StoreName { get; set; }

        public IList<EntityAddressDto> Addresses { get; set; }
        public IList<ContactMethodDto> ContactMethods { get; set; }
        public IList<StoreRoleDto> Positions { get; set; }
        public IList<InventoryDto> Inventory { get; set; }
    }
}
