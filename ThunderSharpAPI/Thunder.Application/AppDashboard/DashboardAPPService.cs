using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thunder.Application.AppDashboard.Interfaces;
using Thunder.Domain.Entities;
using Thunder.Domain.Interfaces.Repositories;

namespace Thunder.Application.AppDashboard
{
    public class DashboardAppService : IDashboardAppService
    {
        private readonly IDashboardRepository _dashboardRepository;
        
        public DashboardAppService(IDashboardRepository dashboardRepository) 
        {
            _dashboardRepository = dashboardRepository;

        }
        public async Task<DashboardMyReservations> GetByID(string id)
        {
            return await _dashboardRepository.GetByID(id);
        }

        public async Task<IEnumerable<DashboardMostReservedActors>> GetMostReservedActors()
        {
            return await _dashboardRepository.GetMostReservedActors();
        }

        public async Task<IEnumerable<DashboardMostReservedDays>> GetMostReservedDays()
        {
            return await _dashboardRepository.GetMostReservedDays();
        }

        public async Task<DashboardTotalReservations> GetTotal()
        {
            return await _dashboardRepository.GetTotal();
        }
    }
}
