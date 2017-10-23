using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;
using System.Threading;
using System.IO;

namespace hasher_win.Controllers
{
    [Route("api/[controller]")]
    public class HasherController : Controller
    {
        // GET api/hasher
        [HttpGet]
        public string Get()
        {
            return String.Format("HASHER running on {0} \n", Dns.GetHostName());
        }

        // GET api/hasher/5
        [HttpGet("{value}")]
        public string Get(string value)
        {
            Byte[] valueBytes = System.Text.Encoding.Unicode.GetBytes(value);
            Byte[] hashedValue;

            Thread.Sleep(100);

            SHA256 mySHA = SHA256.Create();
            hashedValue = mySHA.ComputeHash(valueBytes);
            return System.Text.Encoding.UTF8.GetString(hashedValue);
        }

        // POST api/hasher
        [HttpPost]
        public String Post()
        {
            MemoryStream ms = new MemoryStream();
            Request.Body.CopyTo(ms);

            Byte[] valueBytes = ms.ToArray();
            Byte[] hashedValue;

            SHA256 mySHA = SHA256.Create();
            hashedValue = mySHA.ComputeHash(valueBytes);
           
            return System.Text.Encoding.UTF8.GetString(hashedValue);
        }
    }
}
