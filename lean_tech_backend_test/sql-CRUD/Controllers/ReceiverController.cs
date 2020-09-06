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
    public class ReceiverController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IReceiverService receiverService;

        public ReceiverController(IConfiguration configuration, IReceiverService receiverService)
        {
            this.configuration = configuration;
            this.receiverService = receiverService;
        }

        /// <summary>
        /// Returns all existing Receivers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var receiver = receiverService.GetAll();
                return Ok(receiver);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get a receiver by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var receiver = receiverService.Find(id);
                return Ok(receiver);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Adds a receiver
        /// </summary>
        /// <param name="receiver"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Receiver receiver)
        {
            try
            {
                var resutl = receiverService.Add(receiver);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Edit a receiver
        /// </summary>
        /// <param name="receiver"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] Receiver receiver)
        {
            try
            {
                var resutl = receiverService.Update(receiver);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Delete a receiver
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var resutl = receiverService.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }
    }
}
