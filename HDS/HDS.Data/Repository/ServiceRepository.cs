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
    public class ServiceRepository
    {
        private IHDSContext _dbContext { get; set; }

        public ServiceRepository(IHDSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ServiceVerboseDto Create(CreateServiceDto newService, int orderID)
        {
            newService.ValidateData();
            var service = newService.ToEntity();
            service.OrderID = orderID;
            _dbContext.Service.Add(service);
            _dbContext.SaveChanges();

            return service.ToVerboseDto();
        }

        public void Update(UpdateServiceDto updatedService)
        {
            _dbContext.ValidateData(updatedService);
            var service = _dbContext.Service.SingleOrDefault(o => o.ServiceID == updatedService.ServiceID);
            service.Merge(updatedService);

            _dbContext.SaveChanges();
        }

        public void Delete(int serviceID)
        {
            var check = _dbContext.KeyExists<Service>(serviceID, ValidationMessages.ServiceIDNotFound);
            if (!string.IsNullOrEmpty(check))
            {
                throw new ValidationException(check);
            }
            var service = _dbContext.Service
                .Where(o => o.ServiceID == serviceID)
                .SingleOrDefault();

            //remove records
            _dbContext.Service.RemoveRange(service);

            _dbContext.SaveChanges();
        }
    }
}
