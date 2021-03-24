using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.Models
{
    public class EmployeePosition : DataTable
    {
        [Key]
        public int EmployeePositionID { get; set; }
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public int PositionID { get; set; }

        public Employee Employee { get; set; }
        public StoreRole Position { get; set; }
    }
}
