using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Collection.Core.Repositories;
using Collection.Core.Domain;
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

        public Task AddAsync(Item item)
        {

            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _context.Items
                .Include(x => x.Category)
                .Include(x => x.Producer)
                .Include(x => x.Images).ToListAsync();
        }

        public IQueryable<Item> GetAll()
        {
            return _context.Items
                .Include(x => x.Category)
                .Include(x => x.Producer)
                .Include(x => x.Images);
        }

        public async Task<Item> GetItemAsync(int id)
        {
            var query = _context.Items
                .Include(x => x.Category)
                .Include(x => x.Producer)
                .Include(x => x.Images)
                .Where(x => x.ItemId == id)
                
                .FirstOrDefaultAsync();
            return await query;
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Item item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Item> List(bool readOnly = false)
        {
            throw new NotImplementedException();
        }

        public Item Insert(Item entity, bool forceSave = true)
        {
            throw new NotImplementedException();
        }

        public Item Update(Item entity, bool forceSave = true)
        {
            throw new NotImplementedException();
        }

        public void Delete(Item entity, bool forceSave = true)
        {
            throw new NotImplementedException();
        }
    }
}
