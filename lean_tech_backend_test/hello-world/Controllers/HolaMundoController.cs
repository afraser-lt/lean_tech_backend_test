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
    public class HolaMundoController : ControllerBase
    {
        private readonly ILogger<HolaMundoController> _logger;

        public HolaMundoController(ILogger<HolaMundoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "Hello World";
        }

        /// <summary>
        /// Returns plain text message
        /// </summary>
        /// <returns></returns>
        [HttpGet("txt")]
        public string Txt()
        {
            return "Hello World";
        }

        /// <summary>
        /// Returns a json object
        /// </summary>
        /// <returns></returns>
        [HttpGet("Helloworld/json")]
        public IActionResult Json()
        {
            var message = new { message = "Hello world" };
            return Ok(message);
        }
    }
}
