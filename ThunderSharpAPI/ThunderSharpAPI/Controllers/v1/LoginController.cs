using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Marraia.Notifications.Base;
using Marraia.Notifications.Handlers;
using Marraia.Notifications.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Thunder.Application.AppThunder;
using Thunder.Application.AppThunder.Input;
using Thunder.Application.AppThunder.Interfaces;
using ThunderSharpAPI.SignIn;

namespace ThunderSharpAPI.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : BaseController
    {
        private readonly DomainNotificationHandler _smartNotification;
        private readonly ILoginAppService _loginAppService;
        private readonly IConfiguration _configuration;

        public LoginController(INotificationHandler<DomainNotification> notification, IConfiguration Configuration, ILoginAppService LoginAppService) :base(notification)
        {
            _smartNotification = (DomainNotificationHandler)notification;
            _loginAppService = LoginAppService;
            _configuration = Configuration;
        }


        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<object> Post([FromBody] LoginInput loginInput, [FromServices] SigningConfigurations signingConfigurations)
        {
            try
            {
                var user = await _loginAppService.LoginAsync(loginInput.Email, loginInput.Password);

                if (user != default)
                {
                    var identity = new ClaimsIdentity(
                        new GenericIdentity(user.Email, "Email"),
                        new[] {
                        //new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
                        new Claim(ClaimTypes.Role, user.Profile.Label),
                        new Claim("IdProfile", user.Profile.Id.ToString()),
                        new Claim("NameUser", user.Name)
                        }
                    );

                    var dateCreated = DateTime.Now;
                    var dateExpiration = dateCreated + TimeSpan.FromSeconds(int.Parse(_configuration["TokenSeconds"]));

                    var handler = new JwtSecurityTokenHandler();
                    var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                    {
                        Issuer = _configuration["TokenIssuer"],
                        Audience = _configuration["TokenAudience"],
                        SigningCredentials = signingConfigurations.SigningCredentials,
                        Subject = identity,
                        NotBefore = dateCreated,
                        Expires = dateExpiration
                    });
                    var token = handler.WriteToken(securityToken);

                    return Ok(new
                    {
                        authenticated = true,
                        created = dateCreated.ToString("yyyy-MM-dd HH:mm:ss"),
                        expiration = dateExpiration.ToString("yyyy-MM-dd HH:mm:ss"),
                        accessToken = token,
                        message = "OK"
                    });
                    
                }
                return Unauthorized(_smartNotification.GetNotifications());
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
