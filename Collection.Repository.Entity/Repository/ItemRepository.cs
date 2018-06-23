using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Collection.Repository.Entity.DAL;
using Collection.Core.Repositories;
using Collection.Entity.Item;
using Collection.Repository.Entity.Repository;

namespace ollection.Repository.Entity.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(EntityDBContext context) : base(context)
        {
        }
    }
}
