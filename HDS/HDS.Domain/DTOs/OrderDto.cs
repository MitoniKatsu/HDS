using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.DTOs
{
    public class BaseOrderDto
    {
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
    }
    public class OrderDto : BaseOrderDto
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
    }

    public class OrderVerboseDto : OrderDto
    {
        public IList<ServiceDto> Services { get; set; }
        public IList<OrderDetailDto> OrderDetails { get; set; }
    }

    public class CreateOrderDto : BaseOrderDto
    {
        public IList<CreateServiceDto> Services { get; set; }
        public IList<CreateOrderDetailDto> OrderDetails { get; set; }
    }
}
