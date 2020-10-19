

namespace Thunder.Domain.Entities
{
    public class DashboardMyReservations
    {
        public int MyReservations { get; private set; }

        public DashboardMyReservations(int myReservations) => this.MyReservations = myReservations;
    }
}