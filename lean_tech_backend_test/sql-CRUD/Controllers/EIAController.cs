using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestSharp;
using sql_CRUD.Models;
using sql_CRUD.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace sql_CRUD.Controllers
{
    [Route("api/[controller]")]
    public class EIAController: ControllerBase
    {
        private readonly IConfiguration configuration;

        public EIAController(IConfiguration configuration)
        {
            this.configuration = configuration;            
        }

        /// <summary>
        /// https://www.eia.gov/opendata/qb.php?category=240692&sdid=PET.EMM_EPM0_PTE_NUS_DPG.W
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var client = new RestClient("http://api.eia.gov/series/?api_key="+this.configuration["eiaAPIKey"]+"&series_id=PET.EMM_EPM0_PTE_NUS_DPG.W");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            return Ok(response.Content);            
        }
    }
}
