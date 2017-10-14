using Collection.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collection.Core.Repositories
{
    public interface ICategoryRepository : IRepository
    {
        Task<Category> GetAsync(int id);
        Task<Category> GetAsync(string name);
        Task<IEnumerable<Category>> BrowseAsync();
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task RemoveAsync(int id);
    }
}
