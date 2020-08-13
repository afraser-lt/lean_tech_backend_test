using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestSharp;
using sql_CRUD.Models;
using sql_CRUD.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sql_CRUD.Controllers
{
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IShipmentSerivice shipmentSerivice;

        public DemoController(IConfiguration configuration, IShipmentSerivice shipmentSerivice)
        {
            this.configuration = configuration;
            this.shipmentSerivice = shipmentSerivice;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get([FromQuery] string q, string date = null)
        {
            try
            {
                var result = shipmentSerivice.Search(q, date);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
