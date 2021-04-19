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
    public class OrderDetailRepository
    {
        private IHDSContext _dbContext { get; set; }

        public OrderDetailRepository(IHDSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public OrderDetailVerboseDto Create(CreateOrderDetailDto newOrderDetail, int orderID)
        {
            _dbContext.ValidateData(newOrderDetail);
            var orderDetail = newOrderDetail.ToEntity();
            orderDetail.OrderID = orderID;
            _dbContext.OrderDetail.Add(orderDetail);
            _dbContext.SaveChanges();

            return orderDetail.ToVerboseDto();
        }

        public void Update(UpdateOrderDetailDto updateOrderDetail)
        {
            _dbContext.ValidateData(updateOrderDetail);
            var orderDetail = _dbContext.OrderDetail.SingleOrDefault(o => o.OrderDetailID == updateOrderDetail.OrderDetailID);
            orderDetail.Merge(updateOrderDetail);

            _dbContext.SaveChanges();
        }

        public void Delete(int orderDetailID)
        {
            var check = _dbContext.KeyExists<OrderDetail>(orderDetailID, ValidationMessages.OrderDetailIDNotFound);
            if (!string.IsNullOrEmpty(check))
            {
                throw new ValidationException(check);
            }
            var orderDetail = _dbContext.OrderDetail
                .Where(o => o.OrderDetailID == orderDetailID)
                .SingleOrDefault();

            //remove records
            _dbContext.OrderDetail.RemoveRange(orderDetail);

            _dbContext.SaveChanges();
        }
    }
}
