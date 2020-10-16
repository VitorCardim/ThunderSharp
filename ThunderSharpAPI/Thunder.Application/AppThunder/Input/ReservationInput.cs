using System;
using System.Collections.Generic;
using System.Text;

namespace Thunder.Application.AppThunder.Input
{
    public class ReservationInput
    {
        public int Id { get; set;  }
        public int UserId { get; set; }
        public int ProductionId { get; set; }
        public DateTime Created { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
    }
}
