using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.Models
{
    public class Address : DataTable
    {
        [Key]
        public int AddressID { get; set; }
        [MaxLength(100)]
        [Required]
        public string StreetAddress { get; set; }
        [MaxLength(50)]
        [Required]
        public string City { get; set; }
        [MaxLength(560)]
        [Required]
        public string State { get; set; }
        [MaxLength(10)]
        [Required]
        public string PostalCode { get; set; }
    }
}
