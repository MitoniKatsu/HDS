using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.Models
{
    public class Store : DataTable
    {
        [Key]
        public int StoreID { get; set; }
        [MaxLength(100)]
        [Required]
        public string StoreName { get; set; }

        public ICollection<EntityAddress> Addresses { get; set; }
        public ICollection<ContactMethod> ContactMethods { get; set; }
        public ICollection<StoreRole> Positions { get; set; }
    }
}
