using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thunder.Application.AppDashboard.Interfaces;
using Thunder.Domain.Entities;
using Thunder.Domain.Interfaces.Repository;

namespace Thunder.Application.AppDashboard
{
    public class DashboardAppService : IDashboardAppService
    {
        private readonly IDashboardRepository _dashboardRepository;
        
        public DashboardAppService(IDashboardRepository dashboardRepository) 
        {
            _dashboardRepository = dashboardRepository;

        }
        public Task<DashboardMyReservations> GetByID(string id)
        {
            return _dashboardRepository.GetByID(id);
        }

        public IEnumerable<DashboardMostReservedActors> GetMostReservedActors()
        {
            return _dashboardRepository.GetMostReservedActors();
        }

        public IEnumerable<DashboardMostReservedDays> GetMostReservedDays()
        {
            return _dashboardRepository.GetMostReservedDays();
        }

        public Task<DashboardTotalReservations> GetTotal()
        {
            return _dashboardRepository.GetTotal();
        }
    }
}
