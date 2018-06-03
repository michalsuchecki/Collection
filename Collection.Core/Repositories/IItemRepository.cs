using Collection.Core.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collection.Core.Repositories
{
    public interface IItemRepository : IRepository<Item>
    {
        Task<Item> GetItemAsync(int id);
        Task<IEnumerable<Item>> GetAllAsync();
        IQueryable<Item> GetAll();
        Task AddAsync(Item item);
        Task UpdateAsync(Item item);
        Task RemoveAsync(int id);
    }
}
