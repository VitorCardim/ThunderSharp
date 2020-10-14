using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ThunderSharpAPI.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public async Task<IActionResult> Register([FromServices] IProducerAppService producerAppService);
    }
}
