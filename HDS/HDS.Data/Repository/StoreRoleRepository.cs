using HDS.Domain.DTOs;
using HDS.Domain.Models;
using HDS.Domain.Utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Data.Repository
{
    public class StoreRoleRepository
    {
        private IHDSContext _dbContext { get; set; }

        public StoreRoleRepository(IHDSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public StoreRoleDto Create(CreateStoreRoleDto dto)
        {
            _dbContext.ValidateData(dto);
            var storeRole = dto.ToEntity();
            _dbContext.StoreRole.Add(storeRole);

            _dbContext.SaveChanges();

            return storeRole.ToDto();
        }

        public IList<StoreRoleDto> GetList()
        {
            return _dbContext.StoreRole
                .Include(o => o.EmployeePositions)
                .ThenInclude(o => o.Employee)
                .Select(o => o.ToDto()).ToList();
        }

        public StoreRoleVerboseDto GetByID(int storeRoleID)
        {
            return _dbContext.StoreRole
                .Include(o => o.EmployeePositions)
                .ThenInclude(o => o.Employee)
                .Include(o => o.Store)
                .Where(o => o.StoreRoleID == storeRoleID)
                .SingleOrDefault().ToVerboseDto();
        }

        public void Update(StoreRoleDto updatedStoreRole)
        {
            _dbContext.ValidateData(updatedStoreRole);
            var store = _dbContext.StoreRole.SingleOrDefault(o => o.StoreRoleID == updatedStoreRole.StoreID);
            store.Merge(updatedStoreRole);

            _dbContext.SaveChanges();
        }

        public void Delete(int storeRoleID)
        {
            var check = _dbContext.KeyExists<StoreRole>(storeRoleID, ValidationMessages.StoreRoleIDNotFound);
            if (!string.IsNullOrEmpty(check))
            {
                throw new ValidationException(check);
            }

            var storeRole = _dbContext.StoreRole
                .Include(o => o.EmployeePositions)
                .Where(o => o.StoreRoleID == storeRoleID)
                .SingleOrDefault();
            //employee positions
            var positions = storeRole.EmployeePositions;
            //remove records
            _dbContext.EmployeePosition.RemoveRange(positions);
            _dbContext.StoreRole.Remove(storeRole);

            _dbContext.SaveChanges();
        }
    }
}
