using CarRental.Models;

namespace CarRental.Repositories
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAllCars();
        IEnumerable<Car> GetReservedCars(DateTime startDate, DateTime endDate);
        IEnumerable<Car> SearchCars(string? location, DateTime? startDate, DateTime? endDate, string? make);
        IEnumerable<Car> GetCurrentAvailableCars();
        IEnumerable<Car> GetAvailableCars(DateTime startDate, DateTime endDate);
        Car? GetCarById(int id);
    }
}
