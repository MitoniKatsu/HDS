using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.Models
{
    public class Service : DataTable 
    {
        [Key]
        public int ServiceID { get; set; }
        [Required]
        public int OrderID { get; set; }
        [Required]
        public DateTime ServiceDate { get; set; }
        [MaxLength(400)]
        [Required]
        public string ServiceDescription { get; set; }
        [Required]
        public decimal Price { get; set; }

        public Order Order { get; set; }
    }
}
