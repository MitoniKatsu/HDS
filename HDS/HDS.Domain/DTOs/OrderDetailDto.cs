using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.DTOs
{
    public class OrderDetailDto
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal QuotedPrice { get; set; }
        public int Quantity { get; set; }
        public int QuoteNumber { get; set; }
    }

    public class CustomerQueryOrderDetailsDto : OrderDetailDto
    {

    }

    public class OrderQueryOrderDetailsDto : OrderDetailDto
    {
        public InventoryDto Product { get; set; }
    }
}
