﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thunder.Domain.Interfaces.Repositories;
using FluentValidation;

namespace Thunder.Domain.Entities
{
    public class Production
    {

        public int Id { get; private set; }
        public string Name { get; set; }
        public int PersonId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public User User { get; set; }
        public Reservation Reservation { get; set; }
        public Production(int id, string name, int personId, DateTime created, DateTime updated)
        {
            this.Id = id;
            this.Name = name;
            this.PersonId = personId;
            this.Created = DateTime.Now;
            this.Updated = DateTime.Now;

        }

        public Production(string name, int personId, DateTime created, DateTime updated)
        {
            this.Name = name;
            this.PersonId = personId;
            this.Created = created;
            this.Updated = updated;
        }

        public Production(int id)
        {
            this.Id = id;

        }

        public Production(int id, int personid)
        {
            this.Id = id;
            this.PersonId = personid;

        }

        public Production(User user, Reservation reservation)
        {
            this.User = user;
            this.Reservation = reservation;
        }


        public bool isValid()
        {
            return new ProductionValidator().Validate(this).IsValid;
        }

        public class ProductionValidator : AbstractValidator<Production>
        {
            public ProductionValidator()
            {
                RuleFor(a => a.Name).NotNull();
                RuleFor(a => a.PersonId).NotNull();

            }
        }
    }
}