using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thunder.Domain.Entities;

namespace Thunder.Domain.Interfaces.Repositories
{
    public interface IDashboardRepository
    {
        Task<DashboardMyReservations> GetByID(int id);
        
        Task<DashboardTotalReservations> GetTotal();

        Task<IEnumerable<DashboardMostReservedDays>> GetMostReservedDays();

        Task<IEnumerable<DashboardMostReservedActors>> GetMostReservedActors();
    }
}