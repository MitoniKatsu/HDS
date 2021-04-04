using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.DTOs
{
    public class StoreRoleDto
    {
        public int StoreRoleID { get; set; }
        public string RoleDescription { get; set; }
        public int StoreID { get; set; }

        public StoreDto Store { get; set; }
        public IList<EmployeePositionDto> EmployeePositions { get; set; }
    }
}
