using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using sql_CRUD.Models;
using sql_CRUD.Services.Interfaces;

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

        // GET: api/<ShipmentController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var shipments = shipmentSerivice.GetShipments();
                return Ok(shipments);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        // GET api/<ShipmentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var Shipments = shipmentSerivice.GetShipments(id);
                return Ok(Shipments);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        // POST api/<ShipmentController>
        [HttpPost]
        public IActionResult Post([FromBody] ShipmentViewModel shipment)
        {
            try
            {
                var resutl = shipmentSerivice.AddShipment(shipment);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        // PUT api/<ShipmentController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] ShipmentViewModel shipment, int id)
        {
            try
            {
                var resutl = shipmentSerivice.AddShipment(shipment, id);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        // DELETE api/<ShipmentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var resutl = shipmentSerivice.RemoveShipment(id);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }
    }
}
