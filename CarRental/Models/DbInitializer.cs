using CarRental.Data;
using Microsoft.AspNetCore.Builder;
using System.ComponentModel.DataAnnotations;
using System.IO.Pipelines;

namespace CarRental.Models
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            CarRentalDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<CarRentalDbContext>();

            if (!context.Users.Any())
            {
                context.Users.AddRange(Users);
            }
            if (!context.Cars.Any())
            {
                context.Cars.AddRange(Cars);
            }

            if (!context.Reservations.Any())
            {
                context.AddRange
                (
                    new Reservation { User = Users[1], Car = Cars[0], StartDate = new DateTime(2024, 7, 26), EndDate = new DateTime(2024, 7, 27), TotalPrice = 1234 },
                    new Reservation { User = Users[0], Car = Cars[1], StartDate = new DateTime(2024, 7, 28), EndDate = new DateTime(2024, 7, 30), TotalPrice = 1234 }
                    );
            }

            context.SaveChanges();
        }

        private static List<User>? users;

        public static List<User> Users
        {
            get
            {
                if (users == null)
                {
                    var usersList = new User[]
                                {
                        new User { FirstName = "Peter", LastName = "Parker", Email = "peter.parker@example.com", Password = "IamSpiderman", PhoneNumber = "1234567890", DateOfBirth = new DateTime(1988, 12, 17), AddressLine1 ="Spider Street 123" , City = "Spider City", Country = "United States", DriversLicenseNumber = "789654123" },
                          new User { FirstName = "Michelle", LastName = "Jones", Email = "michelle.jones@example.com", Password = "IamMJ", PhoneNumber = "1234567898", DateOfBirth = new DateTime(1992, 11, 19), AddressLine1 ="MJ Street 123" , City = "MJ City", Country = "United States", DriversLicenseNumber = "789564123" },
                                };

                    users = new List<User>();

                    foreach (User user in usersList)
                    {
                        users.Add(user);
                    }
                }

                return users;
            }
        }

        private static List<Car>? cars;

        public static List<Car> Cars
        {
            get
            {
                if (cars == null)
                {
                    var carsList = new Car[]
                    {
                        new Car { Make = "Toyota", Model= "Corolla", Year = 2012, PricePerDay = 123M, City = "Ohio", ImageUrl="https://picsum.photos/id/237/400/300"},
                        new Car { Make = "Honda", Model= "Fit", Year = 2021, PricePerDay = 241M, City = "Los Angeles", ImageUrl = "https://picsum.photos/id/321/400/300"},
                        new Car { Make = "Mercedes Benz", Model= "Coupe", Year = 2024, PricePerDay = 523M, City = "NYC", ImageUrl="https://picsum.photos/id/32/400/300"},
                        new Car { Make = "BMW", Model= "Coupe", Year = 2018, PricePerDay = 341M, City = "Los Angeles", ImageUrl = "https://picsum.photos/id/49/400/300"},
                        new Car { Make = "Ford", Model= "Mustang", Year = 2012, PricePerDay = 223M, City = "Ohio", ImageUrl="https://picsum.photos/id/77/400/300"},
                        new Car { Make = "Peugeot", Model= "206", Year = 2021, PricePerDay = 241M, City = "Los Angeles", ImageUrl = "https://picsum.photos/id/24/400/300"},
                        new Car { Make = "Peugeot", Model= "207", Year = 2021, PricePerDay = 241M, City = "Los Angeles", ImageUrl = "https://picsum.photos/id/23/400/300"},
                        new Car { Make = "Peugeot", Model= "209", Year = 2021, PricePerDay = 241M, City = "Ohio", ImageUrl = "https://picsum.photos/id/22/400/300"},
                    };

                    cars = new List<Car>();

                    foreach (Car car in carsList)
                    {
                        cars.Add(car);
                    }
                }

                return cars;
            }
        }

    }
}

