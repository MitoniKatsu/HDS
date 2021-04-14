using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.Models
{
    public class ContactMethod : DataTable
    {
        [Key]
        public int ContactMethodID { get; set; }
        [Required]
        public int ContactMethodTypeID { get; set; }
        [MaxLength(100)]
        [Required]
        public string ContactMethodValue { get; set; }

        public ContactMethodType ContactMethodType { get; set; }
    }

    public class CustomerContact : ContactMethod
    {
        [Required]
        public int CustomerID { get; set; }
    }

    public class EmployeeContact : ContactMethod
    {
        [Required]
        public int EmployeeID { get; set; }
    }

    public class StoreContact : ContactMethod
    {
        [Required]
        public int StoreID { get; set; }
    }
}
