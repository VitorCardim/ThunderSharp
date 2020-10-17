using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thunder.Application.AppThunder.Input;
using Thunder.Application.AppThunder.Output;
using Thunder.Domain.Entities;

namespace Thunder.Application.AppThunder.Interfaces
{
    public interface IReservationAppService
    {
        Task<int> InsertAsync(ReservationInput reservation);
        Task<IEnumerable<Reservation>> GetReservationByUserIdAsync(int id);
    }

    
}
