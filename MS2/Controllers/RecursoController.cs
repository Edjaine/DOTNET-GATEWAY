using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MS2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecursoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Microservice 0002") ;
        }
    }
}
