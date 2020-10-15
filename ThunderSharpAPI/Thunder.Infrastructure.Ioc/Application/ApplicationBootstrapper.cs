using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Thunder.Application.AppDashboard.Interfaces;
using Thunder.Application.AppDashboard;
using Thunder.Application.AppThunder.Interfaces;
using Thunder.Application.AppThunder;

namespace Thunder.Infrastructure.Ioc.Application
{
    internal class ApplicationBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddScoped<IDashboardAppService, DashboardAppService>();
            services.AddScoped<ILoginAppService, LoginAppService>();
            services.AddScoped<IRegisterAppService, RegisterAppService>();
        }
    }
}
