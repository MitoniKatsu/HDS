using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.Models
{
    public class Order : DataTable
    {
        [Key]
        public int OrderID { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public int CustomerID { get; set; }
        [Required]
        public int EmployeeID { get; set; }

        public ICollection<Service> Services { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
