using Collection.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collection.Core.Repositories
{
    public interface ICategoryRepository : IRepository
    {
        Task<Category> GetCategoryAsync(int id);
        Task<IEnumerable<Category>> GetAllAsync();
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task RemoveAsync(int id);
    }
}
