using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thunder.Domain.Entities;

namespace Thunder.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserLoginAsync(Login login);

        Task<int> InsertUserAsync(User user);

        Task<User> GetUserByIdAsync(int id);

        Task<IEnumerable<User>> SearchUserByFeeGenresReservationDates(int genreId, decimal fee, DateTime initialReservation, DateTime finalReservation);
    }
}
