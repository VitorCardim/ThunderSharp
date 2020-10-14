

namespace Thunder.Domain.Entities
{
    public class DashboardMyReservations
    {
        public int MyReservations { get; set; }

        public DashboardMyReservations(int myReservations) => this.MyReservations = myReservations;
    }
}