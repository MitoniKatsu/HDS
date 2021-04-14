using HDS.Domain.DTOs;
using HDS.Domain.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Data.Repository
{
    public class TypesRepository
    {
        private IHDSContext _dbContext { get; set; }
        public TypesRepository(IHDSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<AddressTypeDto> GetAddressTypes()
        {
            return _dbContext.AddressType.Select(o => o.ToDto()).ToList();

        }

        public IList<ContactMethodTypeDto> GetContactMethodTypes()
        {
            return _dbContext.ContactMethodType.Select(o => o.ToDto()).ToList();

        }
    }
}
