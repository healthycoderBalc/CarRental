using CarRental.Models;

namespace CarRental.Repositories
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> GetAllReservations();
        IEnumerable<Reservation> GetReservationsByUser(int userId);
        Reservation? GetReservationById(int id);

        void AddReservation(Reservation reservation);
        void UpdateReservation(int id, Reservation reservation);
        void DeleteReservation(int id);
    }
}
