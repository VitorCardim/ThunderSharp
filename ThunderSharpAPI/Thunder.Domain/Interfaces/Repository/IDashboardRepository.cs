using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thunder.Domain.Entities;

namespace Thunder.Domain.Interfaces.Repository
{
    public interface IDashboardRepository
    {
        Task<Dashboard> GetByID(string id);
        
        Task<Dashboard> GetTotal();

        IEnumerable<Dashboard> GetMostReservedDays();

        IEnumerable<Dashboard> GetMostReservedActors();
    }
}