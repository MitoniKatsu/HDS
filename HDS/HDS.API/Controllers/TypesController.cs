using HDS.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HDS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TypesController : ControllerBase
    {
        private readonly ILogger<TypesController> _logger;
        private readonly TypesRepository _repo;

        public TypesController(ILogger<TypesController> logger, TypesRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        [Route("address")]
        public IActionResult GetAddressTypes()
        {
            try
            {
                var result = _repo.GetAddressTypes();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("contactmethod")]
        public IActionResult GetContactMethodTypes()
        {
            try
            {
                var result = _repo.GetContactMethodTypes();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
