using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Collection.Core.Repositories;
using Collection.Entity.Item;
using Collection.Repository.Entity.DAL;

namespace ollection.Repository.Entity.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly EntityDBContext _context;
        public ItemRepository(EntityDBContext context)
        {
            _context = context;
        }

        public Task<Item> GetById(bool readOnly = false)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Item>> List(bool readOnly = false)
        {
            throw new NotImplementedException();
        }

        public Task<Item> Insert(Item entity, bool forceSave = true)
        {
            throw new NotImplementedException();
        }

        public Task<Item> Update(Item entity, bool forceSave = true)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Item entity, bool forceSave = true)
        {
            throw new NotImplementedException();
        }
    }
}
