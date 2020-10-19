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
using Marraia.Notifications.Models;
using Marraia.Notifications.Base;
using Marraia.Notifications.Handlers;
using Microsoft.Extensions.Configuration;
using Thunder.Application.AppThunder.Interfaces;
using Thunder.Application.AppThunder.Input;

namespace ThunderSharpAPI.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionController : BaseController
    {
        private readonly DomainNotificationHandler _notificationHandler;
        private readonly IConfiguration _configuration;
        private readonly IProductionAppService _productionappservice;


        public ProductionController(INotificationHandler<DomainNotification> notification,
                                    IConfiguration configuration, IProductionAppService productionappservice) : base(notification)
        {
            _configuration = configuration;
            _notificationHandler = (DomainNotificationHandler)notification;
            _productionappservice = productionappservice;

        }

        //[Authorize(Roles = "Producer")]
        [HttpGet("search")] //api/Production
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> SearchProductionDetail(int id, int personId)
        {
            return OkOrNoContent(await _productionappservice.SearchProductionDetail(id, personId).ConfigureAwait(false));
        }

        //[Authorize(Roles = "Producer")]
        [HttpGet] //api/Production
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return OkOrNoContent(await _productionappservice.Get());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        //[Authorize(Roles = "Producer")]
        [HttpGet("{id}")] //api/Production
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetByID([FromRoute] int id)
        {
            return OkOrNoContent(await _productionappservice.GetById(id).ConfigureAwait(false));
        }

        //[Authorize(Roles = "Producer")]
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Production([FromBody] ProductionInput productinput)
        {
            try
            {
                var result = await _productionappservice.InsertAsync(productinput.Name, productinput.PersonId, productinput.Created, productinput.Updated);

                if (result > 0)
                {
                    return Ok();
                }
                return OkOrNoContent(_notificationHandler.GetNotifications());

            }
            catch(Exception ex)
            {
                return BadRequest();
            }

        }

    }
}
