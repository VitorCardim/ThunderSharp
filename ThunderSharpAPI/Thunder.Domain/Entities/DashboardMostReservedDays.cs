using System;

namespace Thunder.Domain.Entities
{
    public class DashboardMostReservedDays
    {
        public string ReservedDay { get; set; }

        public string Quantity { get; set; }

        public DashboardMostReservedDays(string reservedDay, string quantity){
            this.ReservedDay = reservedDay;
            this.Quantity = quantity;
        }
    }
}