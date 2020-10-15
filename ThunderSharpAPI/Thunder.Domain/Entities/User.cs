using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Thunder.Domain.Core;

namespace Thunder.Domain.Entities
{
    public class User
    {

        public User(string cpf, string name, string email, string age, string phoneNumber, string password, Profile profile)
        {
            CPF = cpf;
            Name = name;
            Email = email;
            Age = age;
            PhoneNumber = phoneNumber;
            Encrypt(password);
            Profile = profile;
        }

        public string CPF { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public Profile Profile { get; set; }

        public bool IsValid()
        {
            return new UserValidator().Validate(this).IsValid;
        }

        public void Encrypt(string password)
        {
            Password = PasswordHasher.Hash(password);
        }

        public bool PasswordMatch(string password)
        {
            return PasswordHasher.Verify(password, Password);
        }
    }

    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(a => a.Name).NotNull();
            
        }
    }
}
