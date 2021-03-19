using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.Models
{
    public class OrderDetail : DataTable
    {
        [Key]
        public int OrderDetailID { get; set; }
        [Required]
        public int OrderID { get; set; }
        [Required]
        public int ProductID { get; set; }
        public decimal QuotedPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int QuoteNumber { get; set; }

        public Order Order { get; set; }
        public Inventory Product { get; set; }
    }
}
