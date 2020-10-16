using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thunder.Application.AppThunder.Input;
using Thunder.Application.AppThunder.Output;

namespace Thunder.Application.AppThunder.Interfaces
{
    public interface IReservationAppService
    {
        Task<ReservationViewModel> InsertAsync(ReservationInput reservation);
    }
}
