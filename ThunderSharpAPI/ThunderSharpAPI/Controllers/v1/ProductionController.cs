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

namespace ThunderSharpAPI.Controllers.v1
{
    public class ProductionController : ControllerBase
    {
        public IActionResult Register()
        {
            return Ok();
        }

    }
}
