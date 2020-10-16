using System;
using System.Collections.Generic;
using System.Text;
using Thunder.Domain.Entities;

namespace Thunder.Application.AppThunder.Output
{
    public class ReservationViewModel
    {
        public ReservationViewModel(int id, User user, Production production, DateTime created, DateTime initialdate, DateTime finaldate)
        {
            Id = id;
            User = user;
            Production = production;
            Created = created;
            InitialDate = initialdate;
            FinalDate = finaldate;
        }

        public int Id { get; set; }
        public User User { get; set; }
        public Production Production { get; set; }
        public DateTime Created { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }

    }
}
