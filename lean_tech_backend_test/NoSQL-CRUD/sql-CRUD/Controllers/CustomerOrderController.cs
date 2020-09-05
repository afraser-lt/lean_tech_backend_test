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
    public class CustomerOrderController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly ICustomerOderService customerOrderService;

        public CustomerOrderController(IConfiguration configuration, ICustomerOderService customerOrderService)
        {
            this.configuration = configuration;
            this.customerOrderService = customerOrderService;
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
                var customerOrder = customerOrderService.GetAll();
                return Ok(customerOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get a customerOrder by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var customerOrder = customerOrderService.Find(id);
                return Ok(customerOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Adds a customerOrder
        /// </summary>
        /// <param name="customerOrder"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] CustomerOrders customerOrder)
        {
            try
            {
                var resutl = customerOrderService.Add(customerOrder);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Edit a customerOrder
        /// </summary>
        /// <param name="customerOrder"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] CustomerOrders customerOrder)
        {
            try
            {
                var resutl = customerOrderService.Update(customerOrder);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Delete a customerOrder
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var resutl = customerOrderService.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }
    }
}
