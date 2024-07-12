using CarRental.Models;
using CarRental.Repositories;
using CarRental.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRental.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<UserController> _logger;



        public UserController(IUserRepository userRepository, UserManager<User> userManager, ILogger<UserController> logger)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return NotFound();
            }
            var user = _userRepository.GetUserById(userId);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return NotFound();
            }

            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }

            List<SelectListItem> countriesToShow = GetCountryList();

            var model = new EditUserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                DateOfBirth = user.DateOfBirth,
                AddressLine1 = user.AddressLine1,
                AddressLine2 = user.AddressLine2,
                City = user.City,
                Country = user.Country,
                DriversLicenseNumber = user.DriversLicenseNumber,
                Countries = countriesToShow
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userRepository.GetUserById(model.Id);
                if (user == null)
                {
                    return NotFound();
                }

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.DateOfBirth = model.DateOfBirth;
                user.AddressLine1 = model.AddressLine1;
                user.AddressLine2 = model.AddressLine2;
                user.City = model.City;
                user.Country = model.Country;
                user.DriversLicenseNumber = model.DriversLicenseNumber;

                var result = await _userRepository.UpdateUserAsync(user);

                if (result)
                {

                    return RedirectToAction("Details", "User");
                }

                ModelState.AddModelError(string.Empty, "There has been an error");

            }

            model.Countries = GetCountryList();
            return View(model);
        }

        private List<SelectListItem> GetCountryList()
        {
            return new List<SelectListItem>
                {
                    new SelectListItem { Value = "USA", Text = "United States" },
                    new SelectListItem { Value = "CAN", Text = "Canada" },
                    new SelectListItem { Value = "GBR", Text = "United Kingdom" },
                    new SelectListItem { Value = "ARG", Text = "Argentina" },
                    new SelectListItem { Value = "COL", Text = "Colombia" },
                    new SelectListItem { Value = "BRA", Text = "Brasil" },
                };
        }
    }
}
