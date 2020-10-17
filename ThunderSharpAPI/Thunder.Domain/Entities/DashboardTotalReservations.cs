
namespace Thunder.Domain.Entities
{
	public class DashboardTotalReservations
    {
        public int TotalReservations { get; private set; }

        public DashboardTotalReservations(int totalReservations) => this.TotalReservations = totalReservations;

    }
}