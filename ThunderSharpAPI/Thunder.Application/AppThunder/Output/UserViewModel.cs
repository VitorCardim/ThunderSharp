using System;
using System.Collections.Generic;
using System.Text;
using Thunder.Domain.Entities;

namespace Thunder.Application.AppThunder.Output
{
    public class UserViewModel
    {
        public UserViewModel(string cpf, string name, string email, string age, string phoneNumber, Profile profile)
        {
            CPF = cpf;
            Name = name;
            Email = email;
            Age = age;
            PhoneNumber = phoneNumber;
            Profile = profile;
        }

        public string CPF { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string PhoneNumber { get; set; }
        public Profile Profile { get; set; }
    }
}
