using HDS.Domain.DTOs;
using HDS.Domain.Utility;

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
            var entity = newCustomer.ToEntity();
            _dbContext.Customer.Add(entity);
            _dbContext.SaveChanges();

            return entity.ToDto();
        }
    }
}
