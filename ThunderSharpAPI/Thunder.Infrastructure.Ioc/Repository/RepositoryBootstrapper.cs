using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

using Thunder.Domain.Interfaces.Repository;
using Thunder.Infrastructure.Repositories;

namespace Thunder.Infrastructure.Ioc.Application
{
    internal class RepositoryBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddScoped<IDashboardRepository, DashboardRepository>();
        }
    }
}
