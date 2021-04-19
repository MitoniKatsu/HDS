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
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly OrderRepository _repo;

        public OrderController(ILogger<OrderController> logger, OrderRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        /// <summary>
        /// Get a list of order
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetList()
        {
            try
            {
                var result = _repo.GetList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// get an order by orderID
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{orderID}")]
        public IActionResult GetByID([FromRoute] int orderID)
        {
            try
            {
                var result = _repo.GetByID(orderID);

                if (result != null)
                {
                    return Ok(result);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// deletes an order by orderID
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{orderID}")]
        public IActionResult Delete([FromRoute] int orderID)
        {
            try
            {
                _repo.Delete(orderID);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// creates a new order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([Required][FromBody] CreateOrderDto order)
        {
            try
            {
                var result = _repo.Create(order);

                return StatusCode((int)HttpStatusCode.Created, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// updates an existing order
        /// </summary>
        /// <param name="updatedOrder"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateDetails([Required][FromBody] OrderDto updatedOrder)
        {
            try
            {
                _repo.Update(updatedOrder);

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
