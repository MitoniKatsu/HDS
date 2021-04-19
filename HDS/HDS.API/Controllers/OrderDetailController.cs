using HDS.Data.Repository;
using HDS.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HDS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderDetailController : ControllerBase
    {
        private readonly ILogger<OrderDetailController> _logger;
        private readonly OrderDetailRepository _repo;

        public OrderDetailController(ILogger<OrderDetailController> logger, OrderDetailRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        /// <summary>
        /// deletes an order detail by orderDetailID
        /// </summary>
        /// <param name="orderDetailID"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{orderDetailID}")]
        public IActionResult Delete([FromRoute] int orderDetailID)
        {
            try
            {
                _repo.Delete(orderDetailID);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// add a new order detail to an existing order
        /// </summary>
        /// <param name="orderDetail"></param>
        /// <param name="orderID"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("order/{orderID}")]
        public IActionResult Create([Required][FromBody] CreateOrderDetailDto orderDetail, [FromRoute] int orderID)
        {
            try
            {
                var result = _repo.Create(orderDetail, orderID);

                return StatusCode((int)HttpStatusCode.Created, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// updates an existing order detail
        /// </summary>
        /// <param name="updatedorderDetail"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateDetails([Required][FromBody] UpdateOrderDetailDto updatedorderDetail)
        {
            try
            {
                _repo.Update(updatedorderDetail);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
