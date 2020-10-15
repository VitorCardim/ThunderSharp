using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thunder.Domain.Entities;

namespace Thunder.Application.AppDashboard.Interfaces
{
    public interface IDashboardAppService
    {
        Task<DashboardMyReservations> GetByID(string id); /* waiting for method from Person */

        Task<DashboardTotalReservations> GetTotal();

        Task<IEnumerable<DashboardMostReservedDays>> GetMostReservedDays();

        Task<IEnumerable<DashboardMostReservedActors>> GetMostReservedActors();
    }
}