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
    public class EmployeePositionController : ControllerBase
    {
        private readonly ILogger<EmployeePositionController> _logger;
        private readonly EmployeePositionRepository _repo;

        public EmployeePositionController(ILogger<EmployeePositionController> logger, EmployeePositionRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        /// <summary>
        /// deletes an employee position by employeePositionID
        /// </summary>
        /// <param name="employeePositionID"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{employeePositionID}")]
        public IActionResult Delete([FromRoute] int employeePositionID)
        {
            try
            {
                _repo.Delete(employeePositionID);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// creates a new employee position on an existing store role (position)
        /// </summary>
        /// <param name="employeePosition"></param>
        /// <param name="positionID"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("storerole/{positionID}")]
        public IActionResult Create([Required][FromBody] CreateEmployeePositionDto employeePosition, [FromRoute] int positionID)
        {
            try
            {
                var result = _repo.Create(positionID, employeePosition);

                return StatusCode((int)HttpStatusCode.Created, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// updates an existing employee position
        /// </summary>
        /// <param name="updatedEmployeePosition"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateDetails([Required][FromBody] UpdateEmployeePositionDto updatedEmployeePosition)
        {
            try
            {
                _repo.Update(updatedEmployeePosition);

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
