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
        private readonly IDBContext _context;
        public ItemRepository(IDBContext context)
        {
            _context = context;
        }

        public Task AddAsync(Item item)
        {

            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            var query = await _context.GetItems()
                .Include(x => x.Category)
                .Include(x => x.Producer)
                .Include(x => x.Images).ToListAsync();
            return query;
        }

        public async Task<Item> GetItemAsync(int id)
        {
            var query = _context.GetItems()
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
    }
}
