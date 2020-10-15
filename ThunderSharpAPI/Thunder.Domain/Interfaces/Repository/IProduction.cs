using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thunder.Domain.Entities;

namespace Thunder.Domain.Interfaces.Repository
{
    public interface IProduction
    {
        int Insert(Production production);
        Task<Production> GetByID(int id);
        IEnumerable<Production> Get();

    }
}
