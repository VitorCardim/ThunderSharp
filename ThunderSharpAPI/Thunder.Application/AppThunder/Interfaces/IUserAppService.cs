using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thunder.Application.AppThunder.Input;
using Thunder.Application.AppThunder.Output;
using Thunder.Domain.Entities;

namespace Thunder.Application.AppThunder.Interfaces
{
    public interface IUserAppService
    {
        Task<int> InsertAsync(UserInput user);

        Task<IEnumerable<User>> SearchUserByFeeGenresReservationDates(int genreId, decimal fee, DateTime initialReservation, DateTime finalReservation);
    }
}
