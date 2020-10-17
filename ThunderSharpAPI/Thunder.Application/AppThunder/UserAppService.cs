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
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISmartNotification _notification;
        private readonly IProfileRepository _profileRepository;


        public UserAppService(IUserRepository UserRepository, ISmartNotification Notification, IProfileRepository ProfileRepository)
        {
            _userRepository = UserRepository;
            _notification = Notification;
            _profileRepository = ProfileRepository;
        }
        public async Task<int> InsertAsync(UserInput user)
        {
            var profile = await _profileRepository.GetByIdAsync(user.ProfileId);

            if(profile == null)
            {
                _notification.NewNotificationBadRequest("Perfil associado não existe!");
                return default;
            }

            var usr = new User(user.Name, user.Email,user.Age,user.PhoneNumber,user.Password, user.Fee, profile);
            if (usr.IsValid())
            {
                return await _userRepository.InsertUserAsync(usr);
            }
            return 0;
        }

        
    }
}
