using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.DTOs
{
    public class BaseStoreRoleDto
    {
        
        public string RoleDescription { get; set; }
        public int StoreID { get; set; }
    }

    public class StoreRoleDto : BaseStoreRoleDto
    {
        public int StoreRoleID { get; set; }
    }

    public class StoreRoleVerboseDto
    {
        public int StoreRoleID { get; set; }
        public string RoleDescription { get; set; }
        public StoreDto Store { get; set; }
        public IList<EmployeePositionStoreRoleQueryDto> EmployeePositions { get; set; }
    }

    public class StoreRoleStoreQueryDto
    {
        public int StoreRoleID { get; set; }
        public string RoleDescription { get; set; }

        public IList<EmployeePositionStoreRoleQueryDto> EmployeePositions { get; set; }

    }

    public class StoreRoleEmployeePositionQueryDto : BaseStoreRoleDto
    {
        public int StoreRoleID { get; set; }

        public StoreDto Store { get; set; }
    }

    public class CreateStoreRoleDto : BaseStoreRoleDto
    {
        public IList<CreateEmployeePositionDto> EmployeePositions { get; set; }
    }
}
