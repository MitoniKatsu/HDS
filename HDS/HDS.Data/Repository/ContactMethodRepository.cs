using HDS.Domain.DTOs;
using HDS.Domain.Models;
using HDS.Domain.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Data.Repository
{
    public class ContactMethodRepository
    {
        private IHDSContext _dbContext { get; set; }

        public ContactMethodRepository(IHDSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CustomerContactDto Create(int customerID, CreateCustomerContactDto dto)
        {
            _dbContext.ValidateData(dto, customerID);
            var entity = dto.ToEntity();
            entity.CustomerID = customerID;
            _dbContext.CustomerContact.Add(entity);

            _dbContext.SaveChanges();

            return entity.ToDto();
        }

        public EmployeeContactDto Create(int employeeID, CreateEmployeeContactDto dto)
        {
            _dbContext.ValidateData(dto, employeeID);
            var entity = dto.ToEntity();
            entity.EmployeeID = employeeID;
            _dbContext.EmployeeContact.Add(entity);

            _dbContext.SaveChanges();

            return entity.ToDto();
        }

        public StoreContactDto Create(int storeID, CreateStoreContactDto dto)
        {
            _dbContext.ValidateData(dto, storeID);
            var entity = dto.ToEntity();
            entity.StoreID = storeID;
            _dbContext.StoreContact.Add(entity);

            _dbContext.SaveChanges();

            return entity.ToDto();
        }

        public void Update(UpdateContactMethodDto dto)
        {
            _dbContext.ValidateData(dto);
            var entity = _dbContext.ContactMethod.SingleOrDefault(o => o.ContactMethodID == dto.ContactMethodID);
            entity.Merge(dto);

            _dbContext.SaveChanges();
        }

        public void Delete(int contactMethodID)
        {
            var check = _dbContext.KeyExists<ContactMethod>(contactMethodID, ValidationMessages.EntityAddressIDNotFound);
            if (!string.IsNullOrEmpty(check))
            {
                throw new ValidationException(check);
            }
            var contactMethod = _dbContext.ContactMethod
                .SingleOrDefault(o => o.ContactMethodID == contactMethodID);

            _dbContext.ContactMethod.Remove(contactMethod);

            _dbContext.SaveChanges();
        }
    }
}
