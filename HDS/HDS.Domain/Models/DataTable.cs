using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.Models
{
    public abstract class DataTable
    {
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
