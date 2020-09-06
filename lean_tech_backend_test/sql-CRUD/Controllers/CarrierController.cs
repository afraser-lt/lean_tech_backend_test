// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sql_CRUD.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using sql_CRUD.MyModels;
    using sql_CRUD.Services.Interfaces;
    using Swashbuckle.Swagger.Annotations;
    using System;
    using System.Net;

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
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <returns></returns>
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(Carrier))]
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
        public IActionResult Get(int id)
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
        public IActionResult Post([FromBody] Carrier carrier)
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
        public IActionResult Put([FromBody] Carrier carrier)
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
        public IActionResult Delete(int id)
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
