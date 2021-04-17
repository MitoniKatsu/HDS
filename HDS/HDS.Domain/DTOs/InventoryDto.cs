using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.DTOs
{
    public class BaseInventoryDto
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public string ProductDescription { get; set; }
    }
    public class InventoryDto : BaseInventoryDto
    {
        public int ProductID { get; set; }
    }

    public class InventoryVerboseDto : BaseInventoryDto
    {
        public int ProductID { get; set; }
        public string SerialNumber { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public int LocationID { get; set; }
        public BaseStoreDto Location { get; set; }
        public ICollection<OrderDetailDto> ProductOrderDetails { get; set; }
    }

    public class CreateInventoryDto : BaseInventoryDto
    {
        public string SerialNumber { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public int LocationID { get; set; }
    }

    public class UpdateInventoryDto : BaseInventoryDto
    {
        public int ProductID { get; set; }
        public string SerialNumber { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public int LocationID { get; set; }
    }
}
