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
    public class StoreRepository
    {
        private IHDSContext _dbContext { get; set; }

        public StoreRepository(IHDSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public StoreVerboseDto Create(CreateStoreDto dto)
        {
            _dbContext.ValidateData(dto);
            var store = dto.ToEntity();
            _dbContext.Store.Add(store);

            _dbContext.SaveChanges();

            return store.ToVerboseDto();
        }

        public IList<StoreDto> GetList()
        {
            return _dbContext.Store
                .Select(o => o.ToDto()).ToList();
        }

        public StoreVerboseDto GetByID(int storeID)
        {
            return _dbContext.Store
                .Include(o => o.Addresses)
                .ThenInclude(o => o.Address)
                .Include(o => o.Addresses)
                .ThenInclude(o => o.AddressType)
                .Include(o => o.ContactMethods)
                .ThenInclude(o => o.ContactMethodType)
                .Include(o => o.Positions)
                .ThenInclude(o => o.EmployeePositions)
                .ThenInclude(o => o.Employee)
                .Include(o => o.Inventory)
                .Where(o => o.StoreID == storeID)
                .SingleOrDefault().ToVerboseDto();
        }

        public void Update(StoreDto updatedStore)
        {
            _dbContext.ValidateData(updatedStore);
            var store = _dbContext.Store.SingleOrDefault(o => o.StoreID == updatedStore.StoreID);
            store.Merge(updatedStore);

            _dbContext.SaveChanges();
        }

        public void Delete(int storeID)
        {
            var check = _dbContext.KeyExists<Store>(storeID, ValidationMessages.StoreIDNotFound);
            if (!string.IsNullOrEmpty(check))
            {
                throw new ValidationException(check);
            }

            var store = _dbContext.Store
                .Include(o => o.Addresses)
                .ThenInclude(o => o.Address)
                .Include(o => o.Addresses)
                .ThenInclude(o => o.AddressType)
                .Include(o => o.ContactMethods)
                .ThenInclude(o => o.ContactMethodType)
                .Where(o => o.StoreID == storeID)
                .SingleOrDefault();
            //store addresses
            var addresses = store.Addresses.Select(o => o.Address);
            //remove records
            _dbContext.StoreAddress.RemoveRange(store.Addresses);
            _dbContext.Address.RemoveRange(addresses);
            _dbContext.StoreContact.RemoveRange(store.ContactMethods);
            _dbContext.Store.Remove(store);

            _dbContext.SaveChanges();
        }
    }
}
