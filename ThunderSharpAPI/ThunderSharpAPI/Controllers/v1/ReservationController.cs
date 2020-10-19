using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Thunder.Application.AppThunder.Interfaces;
using Marraia.Notifications.Models;
using Marraia.Notifications.Base;
using Thunder.Application.AppThunder.Input;
using System;
using Microsoft.Extensions.Configuration;
using Marraia.Notifications.Handlers;

namespace ThunderSharpAPI.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : BaseController
    {
        private readonly IReservationAppService _reservationService;
        private readonly DomainNotificationHandler _notificationHandler;
        private readonly IConfiguration _configuration;

        public ReservationController(INotificationHandler<DomainNotification> notification,
            IConfiguration Configuration,
            IReservationAppService reservationAppService)
            : base(notification)
        {
            _reservationService = reservationAppService;
            _configuration = Configuration;
            _notificationHandler = (DomainNotificationHandler)notification;
        }

        //[Authorize(Roles = "Actor")]
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

        //[Authorize(Roles = "Producer")]
        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Reservation([FromBody] ReservationInput reservation)
        {
            try
            {
                var result = await _reservationService.InsertAsync(reservation.UserId, reservation.ProductionId, DateTime.Now , reservation.InitialDate, reservation.FinalDate);
                if (result > 0)
                {
                    return Ok();
                }
                return OkOrNoContent(_notificationHandler.GetNotifications());

            }
            catch (Exception ex)
            {
                return BadRequest(); ;
            }
        }
    }
}