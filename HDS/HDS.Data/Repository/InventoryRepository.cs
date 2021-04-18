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
    public class InventoryRepository
    {
        private IHDSContext _dbContext { get; set; }
        public InventoryRepository(IHDSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public InventoryVerboseDto Create(CreateInventoryDto newProduct)
        {
            _dbContext.ValidateData(newProduct);
            var product = newProduct.ToEntity();
            _dbContext.Inventory.Add(product);
            _dbContext.SaveChanges();

            return product.ToVerboseDto();
        }

        public IList<InventoryDto> GetList()
        {
            return _dbContext.Inventory
                .Select(o => o.ToDto()).ToList();
        }

        public InventoryVerboseDto GetByID(int productID)
        {
            return _dbContext.Inventory
                .Include(o => o.ProductOrderDetails)
                .ThenInclude(o => o.Order)
                .Include(o => o.Location)
                .Where(o => o.ProductID == productID)
                .SingleOrDefault().ToVerboseDto();
        }

        public void Update(UpdateInventoryDto updatedProduct)
        {
            _dbContext.ValidateData(updatedProduct);
            var product = _dbContext.Inventory.SingleOrDefault(o => o.ProductID == updatedProduct.ProductID);
            product.Merge(updatedProduct);

            _dbContext.SaveChanges();
        }

        public void Delete(int productID)
        {
            var check = _dbContext.KeyExists<Inventory>(productID, ValidationMessages.ProductIDNotFound);
            if (!string.IsNullOrEmpty(check))
            {
                throw new ValidationException(check);
            }
            var orderCheck = _dbContext.OrderDetail.Any(o => o.ProductID == productID);
            if (orderCheck)
            {
                throw new ValidationException(ValidationMessages.ProductDeleteDenied);
            }

            var product = _dbContext.Inventory
                .Include(o => o.ProductOrderDetails)
                .ThenInclude(o => o.Order)
                .Include(o => o.Location)
                .Where(o => o.ProductID == productID)
                .SingleOrDefault();
            //order details
            var orderDetails = product.ProductOrderDetails;
            //remove records
            _dbContext.OrderDetail.RemoveRange(orderDetails);
            _dbContext.Inventory.RemoveRange(product);

            _dbContext.SaveChanges();
        }
    }
}
