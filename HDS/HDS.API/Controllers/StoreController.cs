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
    public class StoreController : ControllerBase
    {
        private readonly ILogger<StoreController> _logger;
        private readonly StoreRepository _repo;

        public StoreController(ILogger<StoreController> logger, StoreRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        /// <summary>
        /// gets a list of stores
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
        /// get a store by storeID
        /// </summary>
        /// <param name="storeID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{storeID}")]
        public IActionResult GetByID([FromRoute] int storeID)
        {
            try
            {
                var result = _repo.GetByID(storeID);

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
        /// delete a store by storeID
        /// </summary>
        /// <param name="storeID"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{storeID}")]
        public IActionResult Delete([FromRoute] int storeID)
        {
            try
            {
                _repo.Delete(storeID);

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
        /// <param name="store"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([Required][FromBody] CreateStoreDto store)
        {
            try
            {
                var result = _repo.Create(store);

                return StatusCode((int)HttpStatusCode.Created, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// update an existing store's details
        /// </summary>
        /// <param name="updateStore"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateDetails([Required][FromBody] StoreDto updateStore)
        {
            try
            {
                _repo.Update(updateStore);

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
