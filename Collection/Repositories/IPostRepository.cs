using Collection.Models;
using System.Linq;

namespace Collection.Repositories
{
    public interface IPostRepository
    {
        IQueryable<Post> GetAllPosts();
        Post GetPost(int id);
        void Add(Post post);
        void Remove(int id);
        void Update(Post post);
        void Save();
    }
}
