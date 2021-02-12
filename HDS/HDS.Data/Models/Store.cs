using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Data.Models
{
    public class Store : Entity
    {
        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public ICollection<StoreRole> Positions { get; set; }
    }
}
