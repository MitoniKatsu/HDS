using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.DTOs
{
    public class ServiceDto
    {
        public int ServiceID { get; set; }
        public DateTime ServiceDate { get; set; }
        public string ServiceDescription { get; set; }
        public decimal Price { get; set; }

    }

    public class CustomerQueryServiceDto : ServiceDto
    {
    }

    public class ServiceQueryServiceDto : ServiceDto
    {
        public OrderDto Order { get; set; }
    }
}
