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
    public class OrderRepository
    {
        private IHDSContext _dbContext { get; set; }

        public OrderRepository(IHDSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public OrderVerboseDto Create(CreateOrderDto newOrder)
        {
            _dbContext.ValidateData(newOrder);
            var order = newOrder.ToEntity();
            _dbContext.Order.Add(order);
            _dbContext.SaveChanges();

            return order.ToVerboseDto();
        }

        public IList<OrderDto> GetList()
        {
            return _dbContext.Order
                .Select(o => o.ToDto()).ToList();
        }

        public OrderVerboseDto GetByID(int orderID)
        {
            return _dbContext.Order
                .Include(o => o.Services)
                .Include(o => o.OrderDetails)
                .Where(o => o.OrderID == orderID)
                .SingleOrDefault().ToVerboseDto();
        }

        public void Update(OrderDto updatedOrder)
        {
            _dbContext.ValidateData(updatedOrder);
            var order = _dbContext.Order.SingleOrDefault(o => o.OrderID == updatedOrder.OrderID);
            order.Merge(updatedOrder);

            _dbContext.SaveChanges();
        }

        public void Delete(int orderID)
        {
            var check = _dbContext.KeyExists<Order>(orderID, ValidationMessages.OrderIDNotFound);
            if (!string.IsNullOrEmpty(check))
            {
                throw new ValidationException(check);
            }

            var order = _dbContext.Order
                .Include(o => o.Services)
                .Include(o => o.OrderDetails)
                .Where(o => o.OrderID == orderID)
                .SingleOrDefault();
            //remove records
            if (order.Services.Any())
            {
                _dbContext.Service.RemoveRange(order.Services);
            }
            if (order.OrderDetails.Any())
            {
                _dbContext.OrderDetail.RemoveRange(order.OrderDetails);
            }
            _dbContext.Order.Remove(order);

            _dbContext.SaveChanges();
        }
    }
}
