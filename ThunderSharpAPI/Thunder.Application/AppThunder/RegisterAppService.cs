using Marraia.Notifications.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thunder.Application.AppThunder.Interfaces;
using Thunder.Domain.Entities;
using Thunder.Domain.Interfaces.Repositories;

namespace Thunder.Application.AppThunder
{
    public class RegisterAppService : IRegisterAppService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISmartNotification _notification;
        private readonly IProfileRepository _profileRepository;
        public RegisterAppService(IUserRepository UserRepository, ISmartNotification Notification, IProfileRepository ProfileRepository)
        {
            _userRepository = UserRepository;
            _notification = Notification;
            _profileRepository = ProfileRepository;
        }

        public async Task<int> Register(string Name, string Email, string Password, string Age, string PhoneNumber, string IdProfile, decimal fee)
        {
           
            var profile = await _profileRepository.GetByIdAsync(int.Parse(IdProfile));
            
            if(profile != null)
            {
                var User = new User( Name, Email, Age, PhoneNumber, Password, profile, fee);
                if (User.IsValid())
                {
                    var user = await _userRepository.InsertUserAsync(User);
                    if(user > 0)
                    {
                        return user;
                    }
                }
                _notification.NewNotificationBadRequest("Campos Incorretos");
                return default;

            }
            _notification.NewNotificationBadRequest("Perfil Não existe");
            return default;
        }
    }
}
