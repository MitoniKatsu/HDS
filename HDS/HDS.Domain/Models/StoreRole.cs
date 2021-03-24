using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.Models
{
    public class StoreRole : DataTable
    {
        [Key]
        public int StoreRoleID { get; set; }
        [MaxLength(400)]
        [Required]
        public string RoleDescription { get; set; }
        [Required]
        public int StoreID { get; set; }

        public Store Store { get; set; }
        public ICollection<EmployeePosition> EmployeePositions { get; set; }
    }
}
