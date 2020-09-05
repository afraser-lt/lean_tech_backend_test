// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sql_CRUD.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using sql_CRUD.MyModels;
    using sql_CRUD.Services.Interfaces;
    using System;

    [Route("sql/[controller]")]
    [ApiController]
    public class CustomerOrderController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly ICustomerOderService shipmentOrderService;

        public CustomerOrderController(IConfiguration configuration, ICustomerOderService shipmentOrderService)
        {
            this.configuration = configuration;
            this.shipmentOrderService = shipmentOrderService;
        }

        /// <summary>
        /// Returns all existing CustomerOrders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var shipmentOrder = shipmentOrderService.GetAll();
                return Ok(shipmentOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get a shipmentOrder by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var shipmentOrder = shipmentOrderService.Find(id);
                return Ok(shipmentOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Adds a shipmentOrder
        /// </summary>
        /// <param name="shipmentOrder"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] CustomerOrders shipmentOrder)
        {
            try
            {
                var resutl = shipmentOrderService.Add(shipmentOrder);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Edit a shipmentOrder
        /// </summary>
        /// <param name="shipmentOrder"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] CustomerOrders shipmentOrder)
        {
            try
            {
                var resutl = shipmentOrderService.Update(shipmentOrder);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Delete a shipmentOrder
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var resutl = shipmentOrderService.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }
    }
}
