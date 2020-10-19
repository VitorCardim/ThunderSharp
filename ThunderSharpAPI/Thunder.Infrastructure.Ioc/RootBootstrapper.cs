using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Thunder.Infrastructure.Ioc.Application;
using Thunder.Infrastructure.Ioc.Repositories;

namespace Thunder.Infrastructure.Ioc
{
    public class RootBootstrapper
    {
        public void RootRegisterServices(IServiceCollection services)
        {
            new ApplicationBootstrapper().ChildServiceRegister(services);
            new RepositoryBootstrapper().ChildServiceRegister(services);
        }
    }
}
