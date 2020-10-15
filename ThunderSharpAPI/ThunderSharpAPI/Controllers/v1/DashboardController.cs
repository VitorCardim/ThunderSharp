﻿using System;
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

        [Authorize(Roles = "Productor")]
        [HttpGet("{id}")] //api/Dashboard
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]

        public async Task<IActionResult> GetByID([FromRoute] string id)
        { 
            return OkOrNoContent(await _dashboardService
                .GetByID(id)
                .ConfigureAwait(false));
        }
        public async Task<IActionResult> GetTotal() 
        {
            return OkOrNoContent( await _dashboardService.GetTotal());
        }
        public async Task<IActionResult> GetMostReservedDays()
        {
            return OkOrNoContent(await _dashboardService.GetMostReservedDays());
        }
        public async Task<IActionResult> GetMostReservedActors()
        {
            return OkOrNoContent(await _dashboardService.GetMostReservedActors());
        }
    }
}