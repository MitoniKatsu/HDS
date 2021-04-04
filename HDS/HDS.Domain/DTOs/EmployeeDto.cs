using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.DTOs
{
    public class EmployeeDto
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IList<EmployeePositionDto> EmployeePositions { get; set; }
        public IList<EntityAddressDto> Addresses { get; set; }
        public IList<ContactMethodDto> ContactMethods { get; set; }
        public IList<OrderDto> Orders { get; set; }
    }
}
