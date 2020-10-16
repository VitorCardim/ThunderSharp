﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thunder.Domain.Entities;

namespace Thunder.Domain.Interfaces.Repositories
{
    public interface IReservationRepository
    {
        Task<Reservation> GetReservationByUserIdAsync(User user);

        Task<int> InsertReservationAsync(Reservation reservation);

        Task<Boolean> DeleteReservationAsync(Reservation reservation);
    }
}
