using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Collection.Repository.Entity.DAL;
using Collection.Core.Repositories;
using Collection.Entity.Item;
using Collection.Repository.Entity.Repository;

namespace Collection.Repository.Entity.Repository
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(EntityDBContext context) : base(context)
        {
        }
    }
}
