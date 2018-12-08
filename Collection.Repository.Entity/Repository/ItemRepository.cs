using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Collection.Repository.Entity.DAL;
using Collection.Core.Repositories;
using Collection.Entity.Item;
using Collection.Repository.Entity.Repository;
using Collection.Entity.Common;

namespace Collection.Repository.Entity.Repository
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(EntityDBContext context) : base(context)
        {
        }

        public override IQueryable<Item> Search(string search)
        {
            return List(true).Where(x => x.Name.ToLower().Contains(search.ToLower()));
        }

        public IEnumerable<Item> GetItemsByCategory(Category category)
        {
            return List().Where(x => x.CategoryId == category.CategoryId).ToList();
        }

        public IEnumerable<Item> GetItemsByProducer(Producer producer)
        {
            return List().Where(x => x.ProducerId == producer.ProducerId).ToList();
        }
    }
}
