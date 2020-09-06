// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sql_CRUD.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using sql_CRUD.Models;
    using sql_CRUD.MyModels;
    using sql_CRUD.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Net;

    [Route("sql/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IOrderService orderService;

        public OrderController(IConfiguration configuration, IOrderService orderService)
        {
            this.configuration = configuration;
            this.orderService = orderService;
        }

        /// <summary>
        /// Returns all existing Orders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var order = orderService.GetAll();
                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get a order by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var order = orderService.Find(id);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Adds a order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            try
            {
                var resutl = orderService.Add(order);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Edit a order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] Order order)
        {
            try
            {
                var resutl = orderService.Update(order);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Delete a order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var resutl = orderService.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }
    }
}
