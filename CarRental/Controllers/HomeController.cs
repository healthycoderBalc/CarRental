using CarRental.Models;
using CarRental.Repositories;
using CarRental.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;


namespace CarRental.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarRepository _carRepository;

        public HomeController(ILogger<HomeController> logger, ICarRepository carRepository)
        {
            _logger = logger;
            _carRepository = carRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            var cars = _carRepository.GetAllCars();
            var homeViewModel = new HomeViewModel(cars);
            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
