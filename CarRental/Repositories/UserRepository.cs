using CarRental.Data;
using CarRental.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CarRentalDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        public UserRepository(CarRentalDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _dbContext.Users
                 .Include(u => u.Reservations);
        }

        public User? GetUserById(string id)
        {
            return _dbContext.Users
               .Include(u => u.Reservations)
               .Where(u => u.Id == id.ToString())
               .FirstOrDefault();
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            var existingUser = await _dbContext.Users.FindAsync(user.Id);
            if (existingUser == null) return false;

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.DateOfBirth = user.DateOfBirth;
            existingUser.AddressLine1 = user.AddressLine1;
            existingUser.AddressLine2 = user.AddressLine2;
            existingUser.City = user.City;
            existingUser.Country = user.Country;
            existingUser.DriversLicenseNumber = user.DriversLicenseNumber;

            _dbContext.Users.Update(existingUser);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
