using CarRental.Data;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly CarRentalDbContext _dbContext;

        public ReservationRepository(CarRentalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddReservation(Reservation reservation)
        {
            _dbContext.Reservations.Add(reservation);
            _dbContext.SaveChanges();

        }

        public void UpdateReservation(int id, Reservation reservation)
        {
            var existingReservation = GetReservationById(id);
            if (existingReservation != null)
            {
                existingReservation.CarId = reservation.CarId;
                existingReservation.StartDate = reservation.StartDate;
                existingReservation.EndDate = reservation.EndDate;
                existingReservation.TotalPrice = reservation.TotalPrice;
                _dbContext.SaveChanges();
            }
        }

        public void DeleteReservation(int id)
        {
            var existingReservation = GetReservationById(id);
            if (existingReservation != null)
            {
                _dbContext.Reservations.Remove(existingReservation);
            }
            _dbContext.SaveChanges();

        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return _dbContext.Reservations
                .Include(r => r.User)
                .Include(r => r.Car);
        }

        public Reservation? GetReservationById(int id)
        {
            return _dbContext.Reservations
                .Include(r => r.User)
                .Include(r => r.Car)
                .Where(r => r.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<Reservation> GetReservationsByUser(int userId)
        {
            return _dbContext.Reservations
                .Include(r => r.User)
                .Include(r => r.Car)
                .Where(r => r.User.Id == userId.ToString());
        }


    }
}
