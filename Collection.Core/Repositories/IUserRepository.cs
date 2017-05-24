using Collection.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collection.Core.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetUserAsync(int id);
        Task<User> GetUserAsync(string email);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task RemoveAsync(int id);
    }
}
