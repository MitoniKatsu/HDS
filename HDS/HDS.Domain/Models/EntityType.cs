using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.Models
{
    public class EntityType : DataTable
    {
        [Key]
        public int EntityTypeID { get; set; }
        [Required]
        [MaxLength(50)]
        public string EntityTypeName { get; set; }
    }
}
