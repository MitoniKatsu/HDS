using HDS.Domain.DTOs;
using HDS.Domain.Utility;
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
            _dbContext.ValidateData(dto, customerID, ValidationMessages.CustomerIDNotFound);
            var entity = dto.ToEntity();
            entity.CustomerID = customerID;
            _dbContext.CustomerAddress.Add(entity);

            _dbContext.SaveChanges();

            return entity.ToDto();
        }

        public EmployeeAddressDto Create(int employeeID, CreateEmployeeAddressDto dto)
        {
            _dbContext.ValidateData(dto, employeeID, ValidationMessages.EmployeeIDNotFound);
            var entity = dto.ToEntity();
            entity.EmployeeID = employeeID;
            _dbContext.EmployeeAddress.Add(entity);

            _dbContext.SaveChanges();

            return entity.ToDto();
        }

        public StoreAddressDto Create(int storeID, CreateStoreAddressDto dto)
        {
            _dbContext.ValidateData(dto, storeID, ValidationMessages.StoreIDNotFound);
            var entity = dto.ToEntity();
            entity.StoreID = storeID;
            _dbContext.StoreAddress.Add(entity);

            _dbContext.SaveChanges();

            return entity.ToDto();
        }
    }
}
