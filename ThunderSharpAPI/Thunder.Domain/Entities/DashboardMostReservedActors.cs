using System;

namespace Thunder.Domain.Entities
    {
        public class DashboardMostReservedActors
    {
            public string ActorName { get; private set; }

            public string Quantity { get; private set; }

        public DashboardMostReservedActors(string actorName, string quantity)
        {
            this.ActorName = actorName;
            this.Quantity = quantity;
        }


        }
    }
