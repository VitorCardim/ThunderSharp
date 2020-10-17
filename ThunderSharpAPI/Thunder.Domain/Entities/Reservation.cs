using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Thunder.Domain.Core;

namespace Thunder.Domain.Entities
{
    public class Reservation
    {

        public Reservation(User user, Production production, DateTime created, DateTime initialdate, DateTime finaldate)
        {
            User = user;
            Production = production;
            Created = DateTime.Now;
            InitialDate = initialdate;
            FinalDate = finaldate;
        }

        public int Id { get; set;  }
        public User User { get; private set; }
        public Production Production { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime InitialDate { get; private set; }
        public DateTime FinalDate { get; private set; }
        
        public bool IsValid()
        {
            return new ReservationValidator().Validate(this).IsValid;
        }
       
    }

    public class ReservationValidator : AbstractValidator<Reservation>
    {
        public ReservationValidator()
        {
            RuleFor(a => a.User).NotNull();
            RuleFor(a => a.Production).NotNull();
            RuleFor(a => a.InitialDate).NotNull();
            RuleFor(a => a.FinalDate).NotNull();
        }
    }
}