using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Data.Repository
{
    public class EmployeePositionRepository
    {
        private IHDSContext _dbContext { get; set; }
        public EmployeePositionRepository(IHDSContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
