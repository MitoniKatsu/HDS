using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Data.Models
{
    public class Employee : Person
    {
        public int EmployeeID { get; set; }
        public int StoreRoleID { get; set; }
        public StoreRole Position { get; set; }
    }
}
