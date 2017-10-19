using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;
using System.Threading;

namespace hasher_win.Controllers
{
    [Route("api/[controller]")]
    public class HasherController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{value}")]
    
        public string Get(string value)
        {
            Byte[] valueBytes = System.Text.Encoding.Unicode.GetBytes(value);
            Byte[] hashedValue;

            Thread.Sleep(100);

            SHA256 mySHA = SHA256.Create();
            hashedValue = mySHA.ComputeHash(valueBytes);
            return System.Text.Encoding.UTF8.GetString(hashedValue);
/*             var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new StringContent(System.Text.Encoding.UTF8.GetString(hashedValue), System.Text.Encoding.UTF8, "text/plain");
            return resp;
 */        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]string value)
        {
            Byte[] valueBytes = System.Text.Encoding.Unicode.GetBytes(value);
            Byte[] hashedValue;

            SHA256 mySHA = SHA256.Create();
            hashedValue = mySHA.ComputeHash(valueBytes);
            return System.Text.Encoding.UTF8.GetString(hashedValue);
        }
    }
}
