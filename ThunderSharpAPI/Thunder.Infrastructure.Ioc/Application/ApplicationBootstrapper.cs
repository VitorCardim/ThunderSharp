using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Thunder.Application.AppDashboard.Interfaces;
using Thunder.Application.AppDashboard;

namespace Thunder.Infrastructure.Ioc.Application
{
    internal class ApplicationBootsTrapper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddScoped<IDashboardAppService, DashboardAppService>();
        }
    }
}
