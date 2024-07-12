using CarRental.Models;

namespace CarRental.ViewModels
{
    public class ReservationListViewModel
    {
        public IEnumerable<Reservation> Reservations { get; }
        public string? CurrentUser { get; }

        public ReservationListViewModel(IEnumerable<Reservation> reservations, string? currentUser)
        {
            Reservations = reservations;
            CurrentUser = currentUser;
        }


    }
}
