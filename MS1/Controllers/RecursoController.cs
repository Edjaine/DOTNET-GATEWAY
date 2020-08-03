using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MS1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class RecursoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Microservice 0001") ;
        }
    }
}
