using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Collection.Models;
using Microsoft.EntityFrameworkCore;

namespace Collection.Repositories
{
    public class CategoryRepository : ICategoryRepository, IDisposable
    {
        protected readonly ToyContext _context;

        public CategoryRepository(ToyContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.OrderBy(o => o.Name).ToList();
        }

        public  Category GetCategoryById(int Id)
        {
            return _context.Categories.Find(Id);
        }

        public void InsertCategory(Category category)
        {
            _context.Categories.Add(category);
        }

        public void UpdateCategory(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
        }

        public void DeleteCategory(int Id)
        {
            var category = _context.Categories.Find(Id);
            _context.Remove(category);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
