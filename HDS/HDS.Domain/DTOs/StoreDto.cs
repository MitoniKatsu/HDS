using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.DTOs
{
    public class BaseStoreDto
    {
        public string StoreName { get; set; }
    }
    public class StoreDto : BaseStoreDto
    {
        public int StoreID { get; set; }
    }
    public class StoreVerboseDto : BaseStoreDto
    {
        public int StoreID { get; set; }

        public IList<StoreAddressDto> Addresses { get; set; }
        public IList<StoreContactDto> ContactMethods { get; set; }
        public IList<StoreRoleStoreQueryDto> Positions { get; set; }
        public IList<InventoryDto> Inventory { get; set; }
    }

    public class CreateStoreDto : BaseStoreDto
    {
        public IList<CreateStoreAddressDto> Addresses { get; set; }
        public IList<CreateStoreContactDto> ContactMethods { get; set; }
    }
}
