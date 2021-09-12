using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EventsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        public PicController(IWebHostEnvironment env)
        {
            _env = env;
        }
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetImage(int id)
        {
            var webroot = _env.WebRootPath;
            var path = Path.Combine($"{webroot}/pics/",$"event{id}.jfif");
            var buffer = System.IO.File.ReadAllBytes(path);

            return File(buffer, "image/jpeg");
        }
    }
}
