using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.DTOs
{
    public class BaseServiceDto
    {
        public DateTime ServiceDate { get; set; }
        public string ServiceDescription { get; set; }
        public decimal Price { get; set; }
    }
    public class ServiceDto : BaseServiceDto
    {
        public int ServiceID { get; set; }

    }

    public class CreateServiceDto : BaseServiceDto
    {

    }

    public class UpdateServiceDto : BaseServiceDto
    {
        public int OrderID { get; set; }
    }
}
