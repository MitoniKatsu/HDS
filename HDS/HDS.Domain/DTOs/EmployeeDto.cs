using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.DTOs
{
    public class BaseEmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class EmployeeDto : BaseEmployeeDto
    {
        public int EmployeeID { get; set; }
    }

    public class EmployeeVerboseDto : EmployeeDto
    {
        public IList<EmployeePositionEmployeeQueryDto> EmployeePositions { get; set; }
        public IList<EmployeeAddressDto> Addresses { get; set; }
        public IList<EmployeeContactDto> ContactMethods { get; set; }
        public IList<OrderDto> Orders { get; set; }
    }

    public class CreateEmployeeDto : BaseEmployeeDto
    {
        public IList<CreateEmployeeAddressDto> Addresses { get; set; }
        public IList<CreateEmployeeContactDto> ContactMethods { get; set; }
    }
}
