using Collection.Entity.Entity.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collection.Core.Repositories
{
    public interface IProducerRepository
    {
        Task<Producer> GetProducerAsync(int id);
        Task<IEnumerable<Producer>> GetAllAsync();
        Task AddAsync(Producer producer);
        Task UpdateAsync(Producer producer);
        Task RemoveAsync(int id);
    }
}
