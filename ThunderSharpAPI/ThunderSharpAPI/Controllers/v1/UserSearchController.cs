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
    public class UserController : BaseController
    {
        private readonly IUserAppService _userService;
        private readonly DomainNotificationHandler _notificationHandler;
        private readonly IConfiguration _configuration;

        public UserController(INotificationHandler<DomainNotification> notification,
            IConfiguration Configuration,
            IUserAppService userAppService)
            : base(notification)
        {
            _userService = userAppService;
            _configuration = Configuration;
            _notificationHandler = (DomainNotificationHandler)notification;
        }

        //[Authorize(Roles = "Producer")]
        [HttpGet("search")] //api/search
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]

        public async Task<IActionResult> SearchUserByFeeGenresReservationDates(int genreId, decimal fee, DateTime initialReservation, DateTime finalReservation)
        {
            return OkOrNoContent(await _userService
                .SearchUserByFeeGenresReservationDates(genreId, fee, initialReservation, finalReservation)
                .ConfigureAwait(false));
        }
    }
}










