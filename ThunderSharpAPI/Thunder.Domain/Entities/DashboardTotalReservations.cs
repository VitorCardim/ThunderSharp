
namespace Thunder.Domain.Entities
{
	public class DashboardTotalReservations
    {
        public int TotalReservations { get; set; }

        public DashboardTotalReservations(int totalReservations) => this.TotalReservations = totalReservations;

    }
}