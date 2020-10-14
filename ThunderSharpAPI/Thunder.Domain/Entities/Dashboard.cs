using System;
using System.Collections.Generic;
using System.Text;

namespace Thunder.Domain.Entities
{
	public class Dashboard
	{
        public int MyReservations { get; set; }

        public int TotalReservation { get; set; }
        
        public IEnumerable<Tuple> MostReservedDays { get; set; }

        public IEnumerable<Tuple> MostReservedActors { get; set; }
    }
}