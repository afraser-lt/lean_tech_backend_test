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
    public class BOLController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IBOLService BOLService;

        public BOLController(IConfiguration configuration, IBOLService BOLService)
        {
            this.configuration = configuration;
            this.BOLService = BOLService;
        }

        /// <summary>
        /// Returns all existing BOLs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var bol = BOLService.GetAll();
                return Ok(bol);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get a bol by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var bol = BOLService.Find(id);
                return Ok(bol);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Adds a bol
        /// </summary>
        /// <param name="bol"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Bols bol)
        {
            try
            {
                var resutl = BOLService.Add(bol);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Edit a bol
        /// </summary>
        /// <param name="bol"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] Bols bol)
        {
            try
            {
                var resutl = BOLService.Update(bol);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Delete a bol
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {               
                var resutl = BOLService.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }
    }
}
