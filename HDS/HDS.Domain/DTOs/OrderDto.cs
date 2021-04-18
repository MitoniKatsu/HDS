using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.DTOs
{
    public class OrderDto
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }


    }

    public class CustomerQueryOrderDto : OrderDto
    {
        public IList<ServiceDto> Services { get; set; }
        public IList<CustomerQueryOrderDetailsDto> OrderDetails { get; set; }
    }
}
