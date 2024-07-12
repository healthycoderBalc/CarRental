using CarRental.Repositories;
using CarRental.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ICarRepository _carRepository;
        private readonly IUserRepository _userRepository;

        public ReservationController(IReservationRepository reservationRepository, ICarRepository carRepository, IUserRepository userRepository)
        {
            _reservationRepository = reservationRepository;
            _carRepository = carRepository;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            ReservationListViewModel reservationListViewModel =
                new ReservationListViewModel(_reservationRepository.GetAllReservations(), "All Reservations");
            return View(reservationListViewModel);
        }

        public IActionResult Details(int id)
        {
            var reservation = _reservationRepository.GetReservationById(id);
            if (reservation == null) return NotFound();
            return View(reservation);
        }

        public RedirectToActionResult RemoveReservation(int id)
        {
            var selectedReservation = _reservationRepository.GetAllReservations().FirstOrDefault(r => r.Id == id);
            if (selectedReservation != null)
            {
                _reservationRepository.DeleteReservation(id);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult AddReservation(int carId)
        {
            return RedirectToAction("Index");
        }
    }
}
