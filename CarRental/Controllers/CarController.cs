using CarRental.Repositories;
using CarRental.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;
        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public IActionResult Index()
        {
            CarListViewModel carListViewModel =
                new CarListViewModel(_carRepository.GetAllCars());
            return View(carListViewModel);
        }

        public IActionResult Details(int id)
        {
            var car = _carRepository.GetCarById(id);
            if (car == null) return NotFound();
            return View(car);
        }

        public IActionResult Search(string? location, DateTime? startDate, DateTime? endDate, string? make)
        {
            CarListViewModel cars = new CarListViewModel(_carRepository.SearchCars(location, startDate, endDate, make));

            return View(cars);
        }

    }
}
