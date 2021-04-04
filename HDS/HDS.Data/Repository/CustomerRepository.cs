using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Data.Repository
{
    public class CustomerRepository
    {
        private IHDSContext _dbContext { get; set; }
        public CustomerRepository(IHDSContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
