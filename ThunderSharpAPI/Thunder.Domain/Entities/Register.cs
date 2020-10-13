using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Thunder.Domain.Entities
{
    public class Register
    {
        public string CPF { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public int PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public int UserType { get; set; }
        public decimal Fee { get; set; }
        public string Image { get; set; }

        public Register(string cpf, string password, string name, int age, int phoneNumber, string email, int userType, decimal fee, string image)
        {
            this.CPF = cpf;
            this.Password = password;
            this.Name = name;
            this.Age = age;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.UserType = userType;
            this.Fee = fee;
            this.Image = image;
        }
        public bool IsValid()
        {
            return new RegisterValidation().Validate(this).IsValid;
        }
    }
    public class RegisterValidation : AbstractValidator<Register>
    {
        public RegisterValidation()
        {
            RuleFor(a => a.Name).NotNull();
            RuleFor(a => a.Password).NotNull().MaximumLength(12).MinimumLength(8);
            RuleFor(a => a.Age).NotNull();
            RuleFor(a => a.Email).EmailAddress();
            RuleFor(a => a.PhoneNumber).LessThan(12);
            RuleFor(a => a.CPF).Matches(@"/^\d{3}\.\d{3}\.\d{3}\-\d{2}$/");
            RuleFor(a => a.UserType).NotNull();
            RuleFor(a => a.Fee).NotNull();

        }
    }
}
