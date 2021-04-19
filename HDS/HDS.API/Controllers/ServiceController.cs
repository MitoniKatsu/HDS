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
    public class ServiceController : ControllerBase
    {
        private readonly ILogger<ServiceController> _logger;
        private readonly ServiceRepository _repo;

        public ServiceController(ILogger<ServiceController> logger, ServiceRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        /// <summary>
        /// deletes a service by serviceID
        /// </summary>
        /// <param name="serviceID"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{serviceID}")]
        public IActionResult Delete([FromRoute] int serviceID)
        {
            try
            {
                _repo.Delete(serviceID);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// add a new service to an existing order
        /// </summary>
        /// <param name="service"></param>
        /// <param name="orderID"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("order/{orderID}")]
        public IActionResult Create([Required][FromBody] CreateServiceDto service, [FromRoute] int orderID)
        {
            try
            {
                var result = _repo.Create(service, orderID);

                return StatusCode((int)HttpStatusCode.Created, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// updates an existing service
        /// </summary>
        /// <param name="updatedService"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateDetails([Required][FromBody] UpdateServiceDto updatedService)
        {
            try
            {
                _repo.Update(updatedService);

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
