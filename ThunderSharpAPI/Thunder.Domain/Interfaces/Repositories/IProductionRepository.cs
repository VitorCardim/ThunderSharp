using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thunder.Domain.Entities;

namespace Thunder.Domain.Interfaces.Repositories
{
    public interface IProductionRepository
    {
        Task<int> InsertAsync(Production production);
        Task<Production> GetByID(int id);
        Task<IEnumerable<Production>> Get();
        Task<IEnumerable<Production>> SearchProductionDetail(int id, int personid);
    }
}
