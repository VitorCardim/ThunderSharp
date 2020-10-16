using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thunder.Application.AppThunder.Input;
using Thunder.Domain.Entities;

namespace Thunder.Application.AppThunder.Interfaces
{
    public interface IProductionAppService
    {
        Task<Production> Insert(ProductionInput production);
        Task<Production> GetByID(int id);
        IEnumerable<Production> Get();
    }
}
