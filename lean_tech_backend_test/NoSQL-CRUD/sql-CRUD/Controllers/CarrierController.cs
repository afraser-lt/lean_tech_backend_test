// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sql_CRUD.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using nosql_CRUD.Models;
    using nosql_CRUD.Services.Interfaces;
    using System;

    [Route("sql/[controller]")]
    [ApiController]
    public class CarrierController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly ICarrierService carrierService;

        public CarrierController(IConfiguration configuration, ICarrierService carrierService)
        {
            this.configuration = configuration;
            this.carrierService = carrierService;
        }

        /// <summary>
        /// Returns all existing carriers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var carriers = carrierService.GetAll();
                return Ok(carriers);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get a carrier by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var carriers = carrierService.Find(id);
                return Ok(carriers);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Adds a carrier
        /// </summary>
        /// <param name="carrier"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Carriers carrier)
        {
            try
            {
                var resutl = carrierService.Add(carrier);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Edit a carrier
        /// </summary>
        /// <param name="carrier"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] Carriers carrier)
        {
            try
            {
                var resutl = carrierService.Update(carrier);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Delete a carrier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var resutl = carrierService.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }
    }
}
