using System;
using System.Linq;
using Collection.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Collection.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(UserManager<User> userManager,
                           SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<User> GetUserAsync(Guid userId)
        {
            return await _userManager.FindByIdAsync(userId.ToString());
        }

        public async Task<bool> IsOwnerAsync(Guid userId)
        {
            var user = await GetUserAsync(userId);
            if(user != null)
            {
                return await _userManager.IsInRoleAsync(user, "Administrator");
            }
            else
            {
                return await Task.FromResult(false);
            }
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if(user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, password, true, false);
            }
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task RegisterAsync(string username, string password, string email)
        {
            var account = await _userManager.FindByEmailAsync(email);
            if (account != null)
                throw new Exception($"User with email '{email}' already exist");
            else
            {
                var user = new User()
                {
                    Email = email,
                    UserName = username,
                };

                var result = await _userManager.CreateAsync(user, password);

            }
        }
    }
}
