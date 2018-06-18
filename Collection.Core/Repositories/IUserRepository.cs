using Collection.Entity.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collection.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        //Task<User> GetUserAsync(int id);
        //Task<User> GetUserAsync(string email);
        //Task<IEnumerable<User>> GetAllAsync();
        //Task AddAsync(User user);
        //Task UpdateAsync(User user);
        //Task RemoveAsync(int id);
    }
}
