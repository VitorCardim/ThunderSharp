using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thunder.Domain.Entities;

namespace Thunder.Domain.Interfaces.Repository
{
    public interface IRegister
    {
        Task<int> Register(Register register);
        
    }
}
