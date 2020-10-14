using System;

namespace Thunder.Domain.Entities
    {
        public class DashboardMostReservedActors
    {
            public string ActorName { get; set; }

            public string Quantity { get; set; }

        public DashboardMostReservedActors(string actorName, string quantity)
        {
            this.ActorName = actorName;
            this.Quantity = quantity;
        }


        }
    }
