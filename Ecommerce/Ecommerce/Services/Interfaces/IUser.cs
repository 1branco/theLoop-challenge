using Ecommerce.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Services.Interfaces
{
    public interface IUserService
    {
        Task<IList<User>> GetAllUsers();

        Task<User> GetUserById(int userId);

        Task<string> Login(Login login);
    }
}
