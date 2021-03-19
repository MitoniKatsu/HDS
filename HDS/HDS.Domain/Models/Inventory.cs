using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.Models
{
    public class Inventory : DataTable
    {
        [Key]
        public int ProductID { get; set; }
        [MaxLength(100)]
        [Required]
        public string Model { get; set; }
        [MaxLength(100)]
        public string SerialNumber { get; set; }
        [MaxLength(100)]
        [Required]
        public string Brand { get; set; }
        [MaxLength(1000)]
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public decimal Price { get; set; }

        public ICollection<OrderDetail> ProductOrderDetails { get; set; }

    }
}
