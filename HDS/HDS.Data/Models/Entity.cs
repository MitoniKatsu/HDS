using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.Models
{
    public class Entity
    {
        public ICollection<EntityAddress> Addresses { get; set; }
        public ICollection<ContactMethod> ContactMethods { get; set; }
    }
}
