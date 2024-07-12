using CarRental.Data;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarRentalDbContext _dbContext;

        public CarRepository(CarRentalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Car> GetAllCars()
        {
            return _dbContext.Cars
                  .Include(c => c.Reservations);
        }

        public IEnumerable<Car> GetAvailableCars(DateTime startDate, DateTime endDate)
        {
            return _dbContext.Cars
               .Include(c => c.Reservations)
               .Where(c => c.Reservations.Any(r => r.EndDate < startDate || r.StartDate > endDate));
        }

        public IEnumerable<Car> GetReservedCars(DateTime startDate, DateTime endDate)
        {
            return _dbContext.Cars
               .Include(c => c.Reservations)
               .Where(c => c.Reservations.Any(r => r.StartDate <= endDate && r.EndDate >= startDate));
        }
        public Car? GetCarById(int id)
        {
            return _dbContext.Cars
                .Include(c => c.Reservations)
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<Car> GetCurrentAvailableCars()
        {
            DateTime today = DateTime.Today;
            return _dbContext.Cars
                .Include(c => c.Reservations)
                .Where(c => c.Reservations.Any(r => r.EndDate < today || r.StartDate > today));
        }

        public IEnumerable<Car> SearchCars(string? location, DateTime? startDate, DateTime? endDate, string? make)
        {
            var query = _dbContext.Cars.Include(c => c.Reservations).AsQueryable();

            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(c => c.City == location);
            }

            if (!string.IsNullOrEmpty(make))
            {
                query = query.Where(c => c.Make == make);
            }

            if (startDate.HasValue && endDate.HasValue)
            {
                query = query.Where(c => !c.Reservations.Any(r => r.StartDate <= endDate && r.EndDate >= startDate));
            }

            return query.ToList();
        }
    }
}
