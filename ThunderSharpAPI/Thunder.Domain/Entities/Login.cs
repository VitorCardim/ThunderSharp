using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Thunder.Domain.Entities
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public Login(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

        public bool IsValid()
        {
            return new LoginValidator().Validate(this).IsValid;
        }
    }
    public class LoginValidator : AbstractValidator<Login>
    {
        public LoginValidator()
        {
            RuleFor(a => a.Email).EmailAddress();
            RuleFor(a => a.Password).NotNull();
        }
    }
}
