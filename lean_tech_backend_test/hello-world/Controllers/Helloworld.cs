using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace hello_world.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloworldController : ControllerBase
    {
        private readonly ILogger<HolaMundoController> _logger;

        public HelloworldController(ILogger<HolaMundoController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Returns a json object
        /// </summary>
        /// <returns></returns>
        [HttpGet("Json")]
        public IActionResult Json()
        {
            return Ok(new { message = "Hello world" });
        }
    }
}
