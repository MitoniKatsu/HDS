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
    public class EmployeePositionRepository
    {
        private IHDSContext _dbContext { get; set; }
        public EmployeePositionRepository(IHDSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public EmployeePositionDto Create(int storeRoleID, CreateEmployeePositionDto dto)
        {
            _dbContext.ValidateData(dto, storeRoleID);
            var entity = dto.ToEntity();
            entity.PositionID = storeRoleID;
            _dbContext.EmployeePosition.Add(entity);

            _dbContext.SaveChanges();

            return entity.ToDto();
        }

        public void Update(UpdateEmployeePositionDto dto)
        {
            _dbContext.ValidateData(dto);
            var entity = _dbContext.EmployeePosition.SingleOrDefault(o => o.EmployeePositionID == dto.EmployeePositionID);
            entity.Merge(dto);

            _dbContext.SaveChanges();
        }

        public void Delete(int employeePositionID)
        {
            var check = _dbContext.KeyExists<EmployeePosition>(employeePositionID, ValidationMessages.EmployeePositionIDNotFound);
            if (!string.IsNullOrEmpty(check))
            {
                throw new ValidationException(check);
            }
            var employeePosition = _dbContext.EmployeePosition
                .SingleOrDefault(o => o.EmployeePositionID == employeePositionID);

            _dbContext.EmployeePosition.Remove(employeePosition);

            _dbContext.SaveChanges();
        }
    }
}
