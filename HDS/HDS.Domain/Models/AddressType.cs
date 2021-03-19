using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.Models
{
    public class AddressType : DataTable
    {
        [Key]
        public int AddressTypeID { get; set; }
        [MaxLength(50)]
        [Required]
        public string AddressTypeName { get; set; }
    }
}
