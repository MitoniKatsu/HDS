using HDS.Data.Repository;
using HDS.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace HDS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactMethodController : ControllerBase
    {
        private readonly ILogger<ContactMethodController> _logger;
        private readonly ContactMethodRepository _repo;

        public ContactMethodController(ILogger<ContactMethodController> logger, ContactMethodRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        /// <summary>
        /// create a customer contact on an existing customer
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("customer/{customerID}")]
        public IActionResult Create([FromRoute] int customerID, [FromBody] CreateCustomerContactDto dto)
        {
            try
            {
                var result = _repo.Create(customerID, dto);

                return StatusCode((int)HttpStatusCode.Created, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// create a employee contact on an existing employee
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("employee/{employeeID}")]
        public IActionResult Create([FromRoute] int employeeID, [FromBody] CreateEmployeeContactDto dto)
        {
            try
            {
                var result = _repo.Create(employeeID, dto);

                return StatusCode((int)HttpStatusCode.Created, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// create a store contact on an existing store
        /// </summary>
        /// <param name="storeID"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("store/{storeID}")]
        public IActionResult Create([FromRoute] int storeID, [FromBody] CreateStoreContactDto dto)
        {
            try
            {
                var result = _repo.Create(storeID, dto);

                return StatusCode((int)HttpStatusCode.Created, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// updates an existing contact method
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("customer")]
        [Route("employee")]
        [Route("store")]
        public IActionResult Update([FromBody] UpdateContactMethodDto dto)
        {
            try
            {
                _repo.Update(dto);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// deletes an existing contact method
        /// </summary>
        /// <param name="contactMethodID"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("customer/{contactMethodID}")]
        [Route("employee/{contactMethodID}")]
        [Route("store/{contactMethodID}")]
        public IActionResult Delete([FromRoute] int contactMethodID)
        {
            try
            {
                _repo.Delete(contactMethodID);

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
