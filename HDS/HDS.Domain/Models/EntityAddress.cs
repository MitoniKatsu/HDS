using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.Models
{
    public class EntityAddress : DataTable
    {
        [Key]
        public int EntityAddressID { get; set; }
        [Required]
        public int EntityID { get; set; }
        [Required]
        public int AddressID { get; set; }
        [Required]
        public int AddressTypeID { get; set; }
        public bool Primary { get; set; }

        public Address Address { get; set; }
        public AddressType AddressType { get; set; }
    }
}
