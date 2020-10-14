using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thunder.Application.AppDashboard;
using Thunder.Application.AppDashboard.Interfaces;

namespace ThunderSharpAPI.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardAppService _dashboardService;

        [Authorize(Roles = "Productor")]
        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]


        [HttpGet]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]

        public async Task<IActionResult> GetByID([FromRoute] string id)
        { 
            return Ok(await _dashboardService
                .GetByID(id)
                .ConfigureAwait(false));
        }


    }
}