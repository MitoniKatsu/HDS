using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.Models
{
    public abstract class EntityAddress : DataTable
    {
        [Key]
        public int EntityAddressID { get; set; }
        [Required]
        public int AddressID { get; set; }
        [Required]
        public int AddressTypeID { get; set; }
        public bool Primary { get; set; } = false;

        public Address Address { get; set; }
        public AddressType AddressType { get; set; }
    }

    public class CustomerAddress : EntityAddress
    {
        [Required]
        public int CustomerID { get; set; }
    }

    public class EmployeeAddress : EntityAddress
    {
        [Required]
        public int EmployeeID { get; set; }
    }

    public class StoreAddress : EntityAddress
    {
        [Required]
        public int StoreID { get; set; }
    }
}
