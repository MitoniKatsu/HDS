using HDS.Domain.DTOs;
using HDS.Domain.Models;
using HDS.Domain.Utility;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HDS.Data.Repository
{
    public class CustomerRepository
    {
        private IHDSContext _dbContext { get; set; }
        public CustomerRepository(IHDSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CustomerDto CreateCustomer(CreateCustomerDto newCustomer)
        {
            _dbContext.ValidateData(newCustomer);
            var customer = newCustomer.ToEntity();
            _dbContext.Customer.Add(customer);
            _dbContext.SaveChanges();

            return customer.ToDto();
        }

        public IList<CustomerDto> GetList()
        {
            return _dbContext.Customer
                .Include(o => o.Addresses)
                .ThenInclude(o => o.Address)
                .Include(o => o.Addresses)
                .ThenInclude(o => o.AddressType)
                .Include(o => o.ContactMethods)
                .ThenInclude(o => o.ContactMethodType)
                .Select(o => o.ToDto()).ToList();
        }

        public CustomerDto GetByID(int customerID)
        {
            return _dbContext.Customer
                .Include(o => o.Addresses)
                .ThenInclude(o => o.Address)
                .Include(o => o.Addresses)
                .ThenInclude(o => o.AddressType)
                .Include(o => o.ContactMethods)
                .ThenInclude(o => o.ContactMethodType)
                .Where(o => o.CustomerID == customerID)
                .SingleOrDefault().ToDto();
        }

        public void UpdateCustomerDetails(UpdateCustomerDetailsDto updatedCustomer)
        {
            _dbContext.ValidateData(updatedCustomer);
            var customer = _dbContext.Customer.SingleOrDefault(o => o.CustomerID == updatedCustomer.CustomerID);
            customer.Merge(updatedCustomer);

            _dbContext.SaveChanges();
        }

        public void Delete(int customerID)
        {
            var check = _dbContext.KeyExists<Customer>(customerID, ValidationMessages.CustomerIDNotFound);
            if (!string.IsNullOrEmpty(check))
            {
                throw new ValidationException(check);
            }

            var customer = _dbContext.Customer
                .Include(o => o.Addresses)
                .ThenInclude(o => o.Address)
                .Include(o => o.Addresses)
                .ThenInclude(o => o.AddressType)
                .Include(o => o.ContactMethods)
                .ThenInclude(o => o.ContactMethodType)
                .Where(o => o.CustomerID == customerID)
                .SingleOrDefault();
            //store addresses
            var addresses = customer.Addresses.Select(o => o.Address);
            //remove records
            _dbContext.CustomerAddress.RemoveRange(customer.Addresses);
            _dbContext.Address.RemoveRange(addresses);
            _dbContext.CustomerContact.RemoveRange(customer.ContactMethods);
            _dbContext.Customer.Remove(customer);

            _dbContext.SaveChanges();
        }
    }
}
