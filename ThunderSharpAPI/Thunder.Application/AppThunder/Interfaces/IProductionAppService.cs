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
        //Task<int> InsertAsync(ProductionInput productinput);
        Task<Production> GetById(int id);
        IEnumerable<Production> Get();
        Task<int> InsertAsync(string Name, int PersonId, DateTime Created, DateTime Updated);
    }
}
