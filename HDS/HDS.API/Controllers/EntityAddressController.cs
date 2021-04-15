﻿using HDS.Data.Repository;
using HDS.Domain;
using HDS.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HDS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntityAddressController : ControllerBase
    {
        private readonly ILogger<EntityAddressController> _logger;
        private readonly EntityAddressRepository _repo;

        public EntityAddressController(ILogger<EntityAddressController> logger, EntityAddressRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpPost]
        [Route("customer/{customerID}")]
        public IActionResult Create([FromRoute] int customerID, [FromBody] CreateCustomerAddressDto dto)
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

        [HttpPost]
        [Route("employee/{employeeID}")]
        public IActionResult Create([FromRoute] int employeeID, [FromBody] CreateEmployeeAddressDto dto)
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

        [HttpPost]
        [Route("store/{storeID}")]
        public IActionResult Create([FromRoute] int storeID, [FromBody] CreateStoreAddressDto dto)
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

        [HttpPut]
        [Route("customer")]
        public IActionResult UpdateCustomerAddress([FromBody] UpdateEntityAddressDto dto)
        {
            try
            {
                _repo.Update(dto, EntityType.Customer);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("employee")]
        public IActionResult UpdateEmployeeAddress([FromBody] UpdateEntityAddressDto dto)
        {
            try
            {
                _repo.Update(dto, EntityType.Employee);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("store")]
        public IActionResult UpdateStoreAddress([FromBody] UpdateEntityAddressDto dto)
        {
            try
            {
                _repo.Update(dto, EntityType.Store);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{entityAddressID}")]
        public IActionResult Delete([FromRoute] int entityAddressID)
        {
            try
            {
                _repo.Delete(entityAddressID);

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
