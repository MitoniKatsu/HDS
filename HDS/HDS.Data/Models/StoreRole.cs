using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Data.Models
{
    public class StoreRole
    {
        public int StoreRoleID { get; set; }
        public string RoleDescription { get; set; }
        public int StoreID { get; set; }
        public Store Store { get; set; }
    }
}
