using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sql_CRUD.MyModels;
using sql_CRUD.Services.Interfaces;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sql_CRUD.Controllers
{
    [Route("sql/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly ILogger<ShipmentController> logger;
        private readonly IShipmentSerivice shipmentSerivice;

        public ShipmentController(ILogger<ShipmentController> logger, IShipmentSerivice shipmentSerivice)
        {
            this.logger = logger;
            this.shipmentSerivice = shipmentSerivice;
        }

        /// <summary>
        /// Reuturn all shipments
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var shipments = shipmentSerivice.GetAll();
                return Ok(shipments);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Find a shipment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<ShipmentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var Shipments = shipmentSerivice.Find(id);
                return Ok(Shipments);
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
        // POST api/<ShipmentController>
        [HttpPost]
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
        /// Update a shipment
        /// </summary>
        /// <param name="shipment"></param>
        /// <returns></returns>
        // PUT api/<ShipmentController>/5
        [HttpPut()]
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
        // DELETE api/<ShipmentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var resutl = shipmentSerivice.Remove(id);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }
    }
}
