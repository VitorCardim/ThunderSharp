using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Thunder.Domain.Core;

namespace Thunder.Domain.Entities
{
    public class User
    {
        public User(string name, string email, string age, string phoneNumber, string password, Profile profile, decimal fee)
        {
            Name = name;
            Email = email;
            Age = age;
            Fee = fee;
            PhoneNumber = phoneNumber;
            Encrypt(password);
            Profile = profile;
            Created = DateTime.Now;
            Updated = DateTime.Now;
        }


        public User(string name, string email, string age, string phoneNumber, string password, decimal fee, Profile profile)
        {
            Name = name;
            Email = email;
            Age = age;
            PhoneNumber = phoneNumber;
            Password = password;
            Profile = profile;
            Fee = fee;
            Created = DateTime.Now;
            Updated = DateTime.Now;
        }

        public User(int id, string name, string age, decimal fee, string email, string phoneNumber)
        {
            Id = id;
            Name = name;
            Age = age;         
            Fee = fee;
            Email = email;
            PhoneNumber = phoneNumber;
        }
        public User(int Id)
        {
            this.Id = Id;
        }

        public User(int Id, string name)
        {
            this.Id = Id;
            this.Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Age { get; private set; }
        public string PhoneNumber { get; private set; }
        public decimal Fee { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Updated { get; private set; }
        public string Password { get; private set; }
        public Profile Profile { get; private set; }

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
            RuleFor(a => a.Password).MinimumLength(8);
            RuleFor(a => a.Email).EmailAddress();
            RuleFor(a => a.Age).NotNull();
            RuleFor(a => a.PhoneNumber).MaximumLength(15);
        }
    }
}
