using Marraia.Notifications.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thunder.Application.AppThunder.Interfaces;
using Thunder.Application.AppThunder.Output;
using Thunder.Domain.Entities;
using Thunder.Domain.Interfaces.Repositories;

namespace Thunder.Application.AppThunder
{
    public class LoginAppService : ILoginAppService
    {
        private readonly ISmartNotification _notification;
        private readonly IUserRepository _userRepository;

        public LoginAppService(IUserRepository UserRepository, ISmartNotification Notification)
        {
            _userRepository = UserRepository;
            _notification = Notification;
        }
        public async Task<UserViewModel> LoginAsync(string email, string password)
        {
            var Login = new Login(email,password);

            if (Login.IsValid())
            {
                var user = await _userRepository.GetUserLoginAsync(Login);
                if (user == null)
                {
                    _notification.NewNotificationBadRequest("Usuário não encontrado!");
                    return default;
                }
                if (!user.PasswordMatch(password))
                {
                    _notification.NewNotificationBadRequest("Senha incorreta!");
                    return default;
                }

                return new UserViewModel(user.Age, user.Name, user.Email, user.Age, user.PhoneNumber, user.Profile,user.Fee);
            }
            else
            {
                _notification.NewNotificationBadRequest("Campos Incorretos");
                return default;
            }
        }

    }
}
