using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thunder.Domain.Entities;

namespace Thunder.Application.AppThunder.Interfaces
{
    public interface IRegisterAppService
    {
        Task<int> Register(string Name, string Email, string Password, string Age, string PhoneNumber,string IdProfile,decimal fee);
    }
}
