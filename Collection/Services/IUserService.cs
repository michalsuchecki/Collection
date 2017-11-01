using Collection.Models;
using System;
using System.Threading.Tasks;

namespace Collection.Services
{
    public interface IUserService
    {
        Task<User> GetUserAsync(Guid userId);
        Task<bool> IsOwnerAsync(Guid userId);
        Task RegisterAsync(string username, string password, string email);
        Task LoginAsync(string email, string password);
        Task LogoutAsync();
    }
}
