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
    public class StoreRoleController : ControllerBase
    {
        private readonly ILogger<StoreRoleController> _logger;
        private readonly StoreRoleRepository _repo;

        public StoreRoleController(ILogger<StoreRoleController> logger, StoreRoleRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        /// <summary>
        /// gets a list of store roles
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
        /// get a store role by storeRoleID
        /// </summary>
        /// <param name="storeRoleID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{storeRoleID}")]
        public IActionResult GetByID([FromRoute] int storeRoleID)
        {
            try
            {
                var result = _repo.GetByID(storeRoleID);

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
        /// delete a store role by storeRoleID
        /// </summary>
        /// <param name="storeRoleID"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{storeRoleID}")]
        public IActionResult Delete([FromRoute] int storeRoleID)
        {
            try
            {
                _repo.Delete(storeRoleID);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// create a new store
        /// </summary>
        /// <param name="storeRole"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([Required][FromBody] CreateStoreRoleDto storeRole)
        {
            try
            {
                var result = _repo.Create(storeRole);

                return StatusCode((int)HttpStatusCode.Created, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// update an existing store details
        /// </summary>
        /// <param name="updateStoreRole"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateDetails([Required][FromBody] StoreRoleDto updateStoreRole)
        {
            try
            {
                _repo.Update(updateStoreRole);

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
