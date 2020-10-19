using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Thunder.Domain.Interfaces.Repositories;
using Thunder.Infrastructure.Repositories;

namespace Thunder.Infrastructure.Ioc.Repositories
{
    internal class RepositoryBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IDashboardRepository, DashboardRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IProductionRepository, ProductionRepository>();
        }
    }
}
