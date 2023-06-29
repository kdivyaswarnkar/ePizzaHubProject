using ePizzaHub.DAL.Entities;
using ePizzaHub.Models;

namespace ePizzaHub.Repositories.Interfaces
{
    public interface IUserRepository :IRepository<User>
    {
        bool CreateUser(User user, string Role);
        UserModel ValidateUser(string Email,string Password);
    }
}
