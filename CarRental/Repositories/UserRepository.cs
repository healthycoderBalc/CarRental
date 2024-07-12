using CarRental.Data;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CarRentalDbContext _dbContext;

        public UserRepository(CarRentalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _dbContext.Users
                 .Include(u => u.Reservations);
        }

        public User? GetUserById(int id)
        {
            return _dbContext.Users
               .Include(u => u.Reservations)
               .Where(u => u.Id == id.ToString())
               .FirstOrDefault();
        }
    }
}
