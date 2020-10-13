using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thunder.Application.AppThunder.Input;
using Thunder.Application.AppThunder.Interfaces;
using Thunder.Domain.Entities;
using Thunder.Domain.Interfaces.Repository;

namespace Thunder.Application.AppThunder
{
    public class UserAppService : IProducerAppService
    {
        private readonly IAdmin _admin;

        public Task<Producer> SignUP(UserInput user)
        {
            return null;
        }
    }
}
