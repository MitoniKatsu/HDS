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
        [Required]
        public int StoreRoleID { get; set; }


        public StoreRole Position { get; set; }
        public ICollection<EntityAddress> Addresses { get; set; }
        public ICollection<ContactMethod> ContactMethods { get; set; }
    }
}
