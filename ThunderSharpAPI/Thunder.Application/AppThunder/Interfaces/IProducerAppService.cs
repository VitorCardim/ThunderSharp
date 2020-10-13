using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thunder.Application.AppThunder.Input;
using Thunder.Domain.Entities;

namespace Thunder.Application.AppThunder.Interfaces
{
    interface IProducerAppService
    {
        Task<Producer> SignUP(UserInput user);
    }
}
