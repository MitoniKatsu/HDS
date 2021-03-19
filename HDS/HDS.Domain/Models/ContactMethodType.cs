using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.Models
{
    public class ContactMethodType : DataTable
    {
        [Key]
        public int ContactMethodTypeID { get; set; }
        [MaxLength(100)]
        [Required]
        public string ContactMethodTypeName { get; set; }
    }
}
