using System.Collections.Generic;
using Collection.Entity.Common;
using Collection.Entity.Item;

namespace Collection.Core.Repositories
{
    public interface IItemRepository : IRepository<Item>
    {
        IEnumerable<Item> GetItemsByCategory(Category category);
        IEnumerable<Item> GetItemsByProducer(Producer producer);
    }
}
