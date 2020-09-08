using Demo.MyModels;
using Demo.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace Demo.Controllers
{
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IShipmentSerivice shipmentSerivice;
        private readonly ICarrierService carrierSerivice;

        public DemoController(IConfiguration configuration, IShipmentSerivice shipmentSerivice, ICarrierService carrierSerivice)
        {
            this.configuration = configuration;
            this.shipmentSerivice = shipmentSerivice;
            this.carrierSerivice = carrierSerivice;
        }
        
        #region Shipment
        /// <summary>
        /// Returns all existing shipment
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var shipment = shipmentSerivice.GetAll();
                return Ok(shipment);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get a shipment by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("shipment/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var shipment = shipmentSerivice.Find(id);
                return Ok(shipment);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Adds a shipment
        /// </summary>
        /// <param name="shipment"></param>
        /// <returns></returns>
        [HttpPost("shipment")]
        [Authorize(policy: "admin")]
        public IActionResult Post([FromBody] Shipment shipment)
        {
            try
            {
                var resutl = shipmentSerivice.Add(shipment);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Edit a shipment
        /// </summary>
        /// <param name="shipment"></param>
        /// <returns></returns>
        [HttpPut("shipment")]
        [Authorize(policy: "admin")]
        public IActionResult Put([FromBody] Shipment shipment)
        {
            try
            {
                var resutl = shipmentSerivice.Update(shipment);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Delete a shipment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("shipment/{id}")]
        [Authorize(policy: "admin")]
        public IActionResult Delete(int id)
        {
            try
            {
                var resutl = shipmentSerivice.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        [HttpGet("shipment/find")]
        public IActionResult Find(string q, DateTime? date = null)
        {
            try
            {
                var result = shipmentSerivice.FindByCriteria(q, date);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }
        #endregion
        
        #region Carrier
        [HttpGet("carrier")]
        public IActionResult Getcarrier()
        {
            try
            {
                var carriers = carrierSerivice.GetAll();
                return Ok(carriers);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        [HttpGet("carrier/{id}")]
        public IActionResult GetCarrier(int id)
        {
            try
            {
                var carrier = carrierSerivice.Find(id);
                return Ok(carrier);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        [HttpPost("carrier")]
        [Authorize(policy: "admin")]
        public IActionResult PostCarrier([FromBody] Carrier carrier)
        {
            try
            {
                var resutl = carrierSerivice.Add(carrier);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        [HttpPut("carrier")]
        [Authorize(policy: "admin")]
        public IActionResult PutCarrier([FromBody] Carrier carrier)
        {
            try
            {
                var resutl = carrierSerivice.Update(carrier);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        [HttpDelete("carrier/{id}")]
        [Authorize(policy: "admin")]
        public IActionResult DeleteCarrier(int id)
        {
            try
            {
                var resutl = carrierSerivice.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }
        #endregion
    }
}
