using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.DTOs
{
    public class BaseOrderDetailDto
    {
        public int ProductID { get; set; }
        public decimal QuotedPrice { get; set; }
        public int Quantity { get; set; }
        public int QuoteNumber { get; set; }
    }
    public class OrderDetailDto : BaseOrderDetailDto
    {
        public int OrderDetailID { get; set; }
        
    }

    public class OrderDetailVerboseDto : OrderDetailDto
    {
        public int OrderID { get; set; }

    }

    public class CreateOrderDetailDto : BaseOrderDetailDto
    {

    }

    public class UpdateOrderDetailDto : OrderDetailDto
    {
        public int OrderID { get; set; }
    }
}
