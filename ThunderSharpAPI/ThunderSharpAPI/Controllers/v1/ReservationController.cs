using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Thunder.Application.AppThunder.Interfaces;
using Marraia.Notifications.Models;
using Marraia.Notifications.Base;

namespace ThunderSharpAPI.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : BaseController
    {
        private readonly IReservationAppService _reservationService;

        public ReservationController(INotificationHandler<DomainNotification> notification,
            IReservationAppService reservationAppService)
            : base(notification)
        {
            _reservationService = reservationAppService;
        }

        //[Authorize(Roles = "Productor")]
        [HttpGet("actor/{id}")] //api/actor
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]

        public async Task<IActionResult> GetReservationByUserIdAsync([FromRoute] int id)
        {
            return OkOrNoContent(await _reservationService
                .GetReservationByUserIdAsync(id)
                .ConfigureAwait(false));
        }
    }
}