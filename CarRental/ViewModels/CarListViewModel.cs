using CarRental.Models;

namespace CarRental.ViewModels
{
    public class CarListViewModel
    {
        public IEnumerable<Car> Cars { get; }

        public CarListViewModel(IEnumerable<Car> cars)
        {
            Cars = cars;
        }
    }
}
