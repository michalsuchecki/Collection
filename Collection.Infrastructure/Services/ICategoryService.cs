using System.Collections.Generic;
using System.Threading.Tasks;
using Collection.Entity.Entity.Common;
using Collection.Infrastructure.DTO;

namespace Collection.Infrastructure.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<Category> GetAsync(string name);
        Task<IEnumerable<ItemDto>> GetItemsAsync(string name);
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
    }
}