using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Thunder.Application.AppDashboard.Interfaces;
using Marraia.Notifications.Models;
using Marraia.Notifications.Base;
using System.Linq;
using System.Security.Claims;

namespace ThunderSharpAPI.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : BaseController
    {
        private readonly IDashboardAppService _dashboardService;

        public DashboardController(INotificationHandler<DomainNotification> notification,
            IDashboardAppService dashboardAppService)
            :base(notification)
        {
            _dashboardService = dashboardAppService;
        }

        //[Authorize(Roles = "Productor")]
        [HttpGet("dashboard/{id}")] //api/Dashboard
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]

        public async Task<IActionResult> GetByID([FromRoute] int id)
        { 
            return OkOrNoContent(await _dashboardService
                .GetByID(id)
                .ConfigureAwait(false));
        }

        //[Authorize(Roles = "Productor")]
        [HttpGet("dashboard/total")] //api/Dashboard
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetTotal() 
        {

            return OkOrNoContent( await _dashboardService.GetTotal());
        }


        //[Authorize(Roles = "Producer")]
        [HttpGet("dashboard/days")] //api/Dashboard
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetMostReservedDays()
        {
            return OkOrNoContent(await _dashboardService.GetMostReservedDays());

            //Retornar Claims do Client.

            //if (User.Claims.Where(a => a.Type == ClaimTypes.Role).Any())
            //{
            //    var user = User.Claims.Where(a => a.Type == ClaimTypes.Role).FirstOrDefault();

            //    return OkOrNoContent(await _dashboardService.GetMostReservedDays());
            //}

            //return Unauthorized();

        }

        //[Authorize(Roles = "Producer")]
        [HttpGet("dashboard/reserved")] //api/Dashboard
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetMostReservedActors()
        {
            return OkOrNoContent(await _dashboardService.GetMostReservedActors());
        }
    }
}