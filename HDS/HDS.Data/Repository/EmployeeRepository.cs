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
    public class EmployeeRepository
    {
        private IHDSContext _dbContext { get; set; }
        public EmployeeRepository(IHDSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public EmployeeVerboseDto CreateEmployee(CreateEmployeeDto newEmployee)
        {
            _dbContext.ValidateData(newEmployee);
            var employee = newEmployee.ToEntity();
            _dbContext.Employee.Add(employee);
            _dbContext.SaveChanges();

            return employee.ToVerboseDto();
        }

        public IList<EmployeeDto> GetList()
        {
            return _dbContext.Employee
                .Select(o => o.ToDto()).ToList();
        }

        public EmployeeVerboseDto GetByID(int employeeID)
        {
            return _dbContext.Employee
                .Include(o => o.Addresses)
                .ThenInclude(o => o.Address)
                .Include(o => o.Addresses)
                .ThenInclude(o => o.AddressType)
                .Include(o => o.ContactMethods)
                .ThenInclude(o => o.ContactMethodType)
                .Include(o => o.EmployeePositions)
                .ThenInclude(o => o.Position)
                .Include(o => o.Orders)
                .ThenInclude(o => o.OrderDetails)
                .Include(o => o.Orders)
                .ThenInclude(o => o.Services)
                .Where(o => o.EmployeeID == employeeID)
                .SingleOrDefault().ToVerboseDto();
        }

        public void Update(EmployeeDto updatedEmployee)
        {
            _dbContext.ValidateData(updatedEmployee);
            var employee = _dbContext.Employee.SingleOrDefault(o => o.EmployeeID == updatedEmployee.EmployeeID);
            employee.Merge(updatedEmployee);

            _dbContext.SaveChanges();
        }

        public void Delete(int employeeID)
        {
            var check = _dbContext.KeyExists<Employee>(employeeID, ValidationMessages.EmployeeIDNotFound);
            if (!string.IsNullOrEmpty(check))
            {
                throw new ValidationException(check);
            }

            var employee = _dbContext.Employee
                .Include(o => o.Addresses)
                .ThenInclude(o => o.Address)
                .Include(o => o.Addresses)
                .ThenInclude(o => o.AddressType)
                .Include(o => o.ContactMethods)
                .ThenInclude(o => o.ContactMethodType)
                .Where(o => o.EmployeeID == employeeID)
                .SingleOrDefault();
            //store addresses
            var addresses = employee.Addresses.Select(o => o.Address);
            //remove records
            _dbContext.EmployeeAddress.RemoveRange(employee.Addresses);
            _dbContext.Address.RemoveRange(addresses);
            _dbContext.EmployeeContact.RemoveRange(employee.ContactMethods);
            _dbContext.Employee.Remove(employee);

            _dbContext.SaveChanges();
        }
    }
}
