namespace sql_CRUD.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using sql_CRUD.Models;
    using sql_CRUD.Services.Interfaces;
    using System;

    [Route("nosql/[controller]")]
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

        // GET: api/<CarrierController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var carriers = carrierService.GetCarriers();
                //JObject json = JObject.Parse(carriers);
                return Ok(carriers);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        // GET api/<CarrierController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var carriers = carrierService.GetCarriers(id);
                return Ok(carriers);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        // POST api/<CarrierController>
        [HttpPost]
        public IActionResult Post([FromBody] CarrierViewModel carrier)
        {
            try
            {
                var resutl = carrierService.AddCarrier(carrier);
                return Ok(new { status = 200, message = resutl });
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        // PUT api/<CarrierController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] CarrierViewModel carrier, int id)
        {
            try
            {
                var resutl = carrierService.AddCarrier(carrier, id);
                return Ok(new { status = 200, message = resutl });
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        // DELETE api/<CarrierController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var resutl = carrierService.RemoveCarrier(id);
                return Ok(new { status = 200, message = resutl });
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }
    }
}
