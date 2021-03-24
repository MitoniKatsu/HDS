using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.Models
{
    public abstract class DataTable
    {
        [DataType(DataType.Date)]
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
