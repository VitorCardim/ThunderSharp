using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thunder.Domain.Entities;

namespace Thunder.Application.AppDashboard.Interfaces
{
    public interface IDashboardServices
    {
        Task<Dashboard> GetByID(string id);

        Task<Dashboard> GetTotal();

        Task<Dashboard> GetMostReservedDays();

        Task<Dashboard> GetMostReservedActors();
    }
}