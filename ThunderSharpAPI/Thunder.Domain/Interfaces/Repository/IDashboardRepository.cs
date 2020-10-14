using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thunder.Domain.Entities;

namespace Thunder.Domain.Interfaces.Repository
{
    public interface IDashboardRepository
    {
        Task<DashboardMyReservations> GetByID(string id);
        
        Task<DashboardTotalReservations> GetTotal();

        IEnumerable<DashboardMostReservedDays> GetMostReservedDays();

        IEnumerable<DashboardMostReservedActors> GetMostReservedActors();
    }
}