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
    public class PackaginTypeController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IPackaginTypeService packaginTypeService;

        public PackaginTypeController(IConfiguration configuration, IPackaginTypeService packaginTypeService)
        {
            this.configuration = configuration;
            this.packaginTypeService = packaginTypeService;
        }

        /// <summary>
        /// Returns all existing PackaginTypes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var packaginType = packaginTypeService.GetAll();
                return Ok(packaginType);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get a packaginType by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var packaginType = packaginTypeService.Find(id);
                return Ok(packaginType);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Adds a packaginType
        /// </summary>
        /// <param name="packaginType"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] PackaginTypes packaginType)
        {
            try
            {
                var resutl = packaginTypeService.Add(packaginType);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Edit a packaginType
        /// </summary>
        /// <param name="packaginType"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] PackaginTypes packaginType)
        {
            try
            {
                var resutl = packaginTypeService.Update(packaginType);
                return Ok(200);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Delete a packaginType
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var resutl = packaginTypeService.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
        }
    }
}
