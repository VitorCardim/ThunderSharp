using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thunder.Application.AppThunder.Input;
using Thunder.Application.AppThunder.Output;

namespace Thunder.Application.AppThunder.Interfaces
{
    public interface IUserAppService
    {
        Task<int> InsertAsync(UserInput user);
    }
}
