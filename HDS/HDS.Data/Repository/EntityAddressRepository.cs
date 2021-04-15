using HDS.Domain;
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
    public class EntityAddressRepository
    {
        private IHDSContext _dbContext { get; set; }
        public EntityAddressRepository(IHDSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CustomerAddressDto Create(int customerID, CreateCustomerAddressDto dto)
        {
            _dbContext.ValidateData(dto, customerID);
            if (dto.Primary == true)
            {
                FlipPrimaryIfNeeded(null, EntityType.Customer, customerID);
            }
            var entity = dto.ToEntity();
            entity.CustomerID = customerID;
            _dbContext.CustomerAddress.Add(entity);

            _dbContext.SaveChanges();

            return entity.ToDto();
        }

        public EmployeeAddressDto Create(int employeeID, CreateEmployeeAddressDto dto)
        {
            _dbContext.ValidateData(dto, employeeID);
            if (dto.Primary == true)
            {
                FlipPrimaryIfNeeded(null, EntityType.Employee, employeeID);
            }
            var entity = dto.ToEntity();
            entity.EmployeeID = employeeID;
            _dbContext.EmployeeAddress.Add(entity);

            _dbContext.SaveChanges();

            return entity.ToDto();
        }

        public StoreAddressDto Create(int storeID, CreateStoreAddressDto dto)
        {
            _dbContext.ValidateData(dto, storeID);
            if (dto.Primary == true)
            {
                FlipPrimaryIfNeeded(null, EntityType.Store, storeID);
            }
            var entity = dto.ToEntity();
            entity.StoreID = storeID;
            _dbContext.StoreAddress.Add(entity);

            _dbContext.SaveChanges();

            return entity.ToDto();
        }

        public void Update(UpdateEntityAddressDto dto, EntityType type)
        {
            _dbContext.ValidateData(dto);
            if (dto.Primary == true)
            {
                FlipPrimaryIfNeeded(dto.EntityAddressID, type);
            }
            var entity = _dbContext.EntityAddress.SingleOrDefault(o => o.EntityAddressID == dto.EntityAddressID);
            entity.Merge(dto);

            _dbContext.SaveChanges();
        }

        public void Delete(int entityaddressID)
        {
            var check = _dbContext.KeyExists<EntityAddress>(entityaddressID, ValidationMessages.EntityAddressIDNotFound);
            if (!string.IsNullOrEmpty(check))
            {
                throw new ValidationException(check);
            }
            var entityaddress = _dbContext.EntityAddress
                .Include(o => o.Address)
                .SingleOrDefault(o => o.EntityAddressID == entityaddressID);

            _dbContext.Address.Remove(entityaddress.Address);
            _dbContext.EntityAddress.Remove(entityaddress);

            _dbContext.SaveChanges();
        }

        private void FlipPrimaryIfNeeded(int? entityAddressID, EntityType type, int? id = null)
        {
            switch (type)
            {
                case EntityType.Customer:
                    var customerID = id ?? _dbContext.CustomerAddress.SingleOrDefault(o => o.EntityAddressID == entityAddressID)?.CustomerID;
                    _dbContext.CustomerAddress.Where(o => o.CustomerID == customerID && o.Primary).ToList().ForEach(o => o.Primary = false);
                    break;
                case EntityType.Employee:
                    var employeeID = id ?? _dbContext.EmployeeAddress.SingleOrDefault(o => o.EntityAddressID == entityAddressID)?.EmployeeID;
                    _dbContext.EmployeeAddress.Where(o => o.EmployeeID == employeeID && o.Primary).ToList().ForEach(o => o.Primary = false);
                    break;
                case EntityType.Store:
                    var storeID = id ?? _dbContext.StoreAddress.SingleOrDefault(o => o.EntityAddressID == entityAddressID)?.StoreID;
                    _dbContext.StoreAddress.Where(o => o.StoreID == storeID && o.Primary).ToList().ForEach(o => o.Primary = false);
                    break;
                default:
                    break;
            }
        }
    }
}
