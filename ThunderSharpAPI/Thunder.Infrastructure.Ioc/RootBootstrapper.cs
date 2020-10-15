using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Thunder.Infrastructure.Ioc.Application;

namespace Thunder.Infrastructure.Ioc
{
    public class RootBooststrapper
    {
        public void RootRegisterServices(IServiceCollection services)
        {
            new ApplicationBootstrapper().ChildServiceRegister(services);
            new RepositoryBootstrapper().ChildServiceRegister(services);
        }
    }
}
