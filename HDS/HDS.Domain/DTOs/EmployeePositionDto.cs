using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.DTOs
{
    public class BaseEmployeePositionDto
    {
        public int EmployeeID { get; set; }
    }

    public class EmployeePositionDto : BaseEmployeePositionDto
    {
        public int EmployeePositionID { get; set; }
        public int PositionID { get; set; }


        public BaseEmployeeDto Employee { get; set; }
        public StoreRoleDto Position { get; set; }
    }

    public class EmployeePositionStoreRoleQueryDto : BaseEmployeePositionDto
    {
        public int EmployeePositionID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class EmployeePositionEmployeeQueryDto
    {
        public int EmployeePositionID { get; set; }
        public int PositionID { get; set; }

        public BaseStoreRoleDto Position { get; set; }
    }

    public class CreateEmployeePositionDto : BaseEmployeePositionDto
    {
    }

    public class UpdateEmployeePositionDto : BaseEmployeePositionDto
    {
        public int EmployeePositionID { get; set; }
        public int PositionID { get; set; }
    }
}
