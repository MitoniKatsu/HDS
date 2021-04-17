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
    public class InventoryController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly InventoryRepository _repo;

        public InventoryController(ILogger<InventoryController> logger, InventoryRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        /// <summary>
        /// Get a list of products
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
        /// get a product by productID
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{productID}")]
        public IActionResult GetByID([FromRoute] int productID)
        {
            try
            {
                var result = _repo.GetByID(productID);

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
        /// deletes a product by productID and associated order detail items
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{productID}")]
        public IActionResult Delete([FromRoute] int productID)
        {
            try
            {
                _repo.Delete(productID);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// creates a new product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([Required][FromBody] CreateInventoryDto product)
        {
            try
            {
                var result = _repo.Create(product);

                return StatusCode((int)HttpStatusCode.Created, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// updates an existing product's details
        /// </summary>
        /// <param name="updatedProduct"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateDetails([Required][FromBody] UpdateInventoryDto updatedProduct)
        {
            try
            {
                _repo.Update(updatedProduct);

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
