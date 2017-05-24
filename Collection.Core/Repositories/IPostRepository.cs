using Collection.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collection.Core.Repositories
{
    public interface IPostRepository : IRepository
    {
        Task<Post> GetPostAsync(int id);
        Task<IEnumerable<Post>> GetAllAsync();
        Task AddAsync(Post post);
        Task UpdateAsync(Post post);
        Task RemoveAsync(int id);
    }
}
