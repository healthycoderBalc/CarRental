using CarRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Car> Cars { get;}
        public HomeViewModel(IEnumerable<Car> cars)
        {
            Cars = cars;
        }

    }
}
