using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.DTOs
{
    public class EmployeePositionDto
    {
        public int EmployeePositionID { get; set; }
        public int EmployeeID { get; set; }
        public int PositionID { get; set; }

        public EmployeeDto Employee { get; set; }
        public StoreRoleDto Position { get; set; }
    }
}
