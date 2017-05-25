using Collection.Core.Domain;
using System.Linq;

namespace Collection.Infrastructure.DAL
{
    public interface IDBContext
    {
        IQueryable<User> GetUsers();
        IQueryable<Producer> GetProducers();
        IQueryable<Category> GetCategories();
        IQueryable<Image> GetImages();
        IQueryable<Item> GetItems();
        IQueryable<Post> GetPosts();

        //void UpdateEntity<T>(T entity) where T : class;
    }
}
