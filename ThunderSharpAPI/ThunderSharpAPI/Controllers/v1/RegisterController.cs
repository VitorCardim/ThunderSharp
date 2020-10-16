using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marraia.Notifications;
using Marraia.Notifications.Base;
using Marraia.Notifications.Handlers;
using Marraia.Notifications.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Thunder.Application.AppThunder.Input;
using Thunder.Application.AppThunder.Interfaces;
using Thunder.Domain.Entities;

namespace ThunderSharpAPI.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly DomainNotificationHandler _notificationHandler;
        private readonly IRegisterAppService _registerAppService;
        public RegisterController(INotificationHandler<DomainNotification> notification, 
            IConfiguration Configuration, IRegisterAppService RegisterAppService):base(notification)
        {
            _configuration = Configuration;
            _notificationHandler = (DomainNotificationHandler)notification;
            _registerAppService = RegisterAppService;
        }


        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Register([FromBody] RegisterInput register)
        {
            try
            {
                var result = await _registerAppService.Register(register.Name, register.Email, register.Password,
                    register.Age,register.PhoneNumber,register.IdProfile,register.Fee);
                if(result > 0)
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
