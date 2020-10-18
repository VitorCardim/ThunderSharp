﻿using System;
using System.Collections.Generic;
using System.Text;
using Thunder.Domain.Entities;

namespace Thunder.Application.AppThunder.Output
{
    public class UserViewModel
    {
        public UserViewModel(string name, string email, string age, string phoneNumber, Profile profile,decimal fee)
        {
            Name = name;
            Email = email;
            Age = age;
            PhoneNumber = phoneNumber;
            Profile = profile;
            Fee = fee;
        }

        public decimal Fee { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string PhoneNumber { get; set; }
        public Profile Profile { get; set; }
    }
}
