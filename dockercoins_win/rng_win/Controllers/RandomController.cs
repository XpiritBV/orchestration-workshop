using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace rng_win.Controllers
{
    [Route("api/[controller]")]
    public class RandomController : Controller
    {
        private readonly ILogger _logger;
        
        public RandomController(ILogger<RandomController> logger)
        {
            _logger = logger;
        }
        // GET api/random
        [HttpGet]
        public IEnumerable<string> Get()
        {
            string hostname = Request.Host.Host;
            return new string[] { $"RNG running on {hostname}" };
        }

        // GET api/random/5
        [HttpGet("{length}")]
        public string Get(int length)
        {
            _logger.LogInformation($"Generating random number of length {length}");
            byte[] array = new byte[length];
            Random rnd = new Random();
            rnd.NextBytes(array);
            
            // Simulate a little bit of delay
            System.Threading.Thread.Sleep(100);

            return System.Text.Encoding.UTF8.GetString(array);
        }
    }
}
