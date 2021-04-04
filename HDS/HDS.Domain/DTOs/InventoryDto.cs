using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.DTOs
{
    public class InventoryDto
    {
        public int ProductID { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string Brand { get; set; }
        public string ProductDescription { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public int LocationID { get; set; }

        public StoreDto Location { get; set; }
    }
}
