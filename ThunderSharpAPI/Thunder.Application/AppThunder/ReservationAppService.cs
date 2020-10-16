using Marraia.Notifications.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thunder.Application.AppThunder.Input;
using Thunder.Application.AppThunder.Interfaces;
using Thunder.Application.AppThunder.Output;
using Thunder.Domain.Entities;
using Thunder.Domain.Interfaces.Repositories;

namespace Thunder.Application.AppThunder
{
    public class ReservationAppService : IReservationAppService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ISmartNotification _notification;
        private readonly IUserRepository _userRepository;
        private readonly IProductionRepository _productionRepository;


        public ReservationAppService(IReservationRepository ReservationRepository, ISmartNotification Notification, IUserRepository UserRepository, IProductionRepository ProductionRepository)
        {
            _reservationRepository = ReservationRepository;
            _productionRepository = ProductionRepository;
            _userRepository = UserRepository;
            _notification = Notification;
            
        }
        public async Task<int> InsertAsync(ReservationInput reservation)
        {
            var production = await _productionRepository.GetByID(reservation.ProductionId);

            if(production == null)
            {
                _notification.NewNotificationBadRequest("Production doesn't exist to create a Reservation!");
                return default;
            }
            
            var user = await _userRepository.GetUserByIdAsync(reservation.UserId);

            if (user == null)
            {
                _notification.NewNotificationBadRequest("User doesn't exist to create a Reservation!");
                return default;
            }


            var reserv = new Reservation(reservation.Id, user, production, reservation.Created, reservation.InitialDate, reservation.FinalDate);
            if (reserv.IsValid())
            {
                return await _reservationRepository.InsertReservationAsync(reserv);
            }

            return 0;
  

        }
    }
}
