using CarRental.Models;

namespace CarRental.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User? GetUserById(int id);
    }
}
