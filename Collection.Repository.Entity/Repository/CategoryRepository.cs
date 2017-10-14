using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Collection.Core.Domain;
using Collection.Core.Repositories;
using Collection.Repository.Entity.DAL;
using Microsoft.EntityFrameworkCore;

namespace Collection.Repository.Entity.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EntityDBContext _context;

        public CategoryRepository(EntityDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> BrowseAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetAsync(int id)
        {
            return await _context.Categories.Where(x => x.CategoryId == id).FirstOrDefaultAsync();
        }

        public async Task<Category> GetAsync(string name)
        {
            return await _context.Categories.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Category category)
        {
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {

            await Task.CompletedTask;
            throw new System.NotImplementedException();
        }

        public async Task RemoveAsync(int id)
        {
            var category = await GetAsync(id);
            if(category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}