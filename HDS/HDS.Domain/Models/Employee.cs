using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.Models
{
    public class Employee : DataTable
    {
        [Key]
        public int EmployeeID { get; set; }
        [MaxLength(100)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(100)]
        [Required]
        public string LastName { get; set; }

        public ICollection<EmployeePosition> EmployeePositions { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<EmployeeAddress> Addresses { get; set; }
        public ICollection<EmployeeContact> ContactMethods { get; set; }
    }
}
