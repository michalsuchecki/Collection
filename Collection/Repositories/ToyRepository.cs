using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Collection.Models;
using Microsoft.EntityFrameworkCore;

namespace Collection.Repositories
{
    public class ToyRepository : IToyRepository, IDisposable
    {
        private ToyContext _context;

        public ToyRepository(ToyContext context)
        {
            _context = context;
        }

        public Toy GetToyByID(int toyId)
        {
            return _context.Toys
                         .Include(i => i.Category)
                         .Include(i => i.Producer)
                         .Include(i => i.Gallery)
                         .SingleOrDefault(s => s.ToyID == toyId);
        }

        public IEnumerable<Toy> GetMyToys()
        {
            var result = _context.Toys
                         .Include(i => i.Category)
                         .Include(i => i.Producer)
                         .Include(i => i.Gallery)
                         .Where(i => i.InCollection)
                         .OrderBy(i => i.Name)
                         .ToList();
            return result;
        }

        public IEnumerable<Toy> GetMyToysByCategory(int categoryId)
        {
            var result = _context.Toys
                         .Include(i => i.Category)
                         .Include(i => i.Producer)
                         .Include(i => i.Gallery)
                         .Where(i => i.InCollection && i.Category.Id == categoryId)
                         .OrderBy(i => i.Name)
                         .ToList();
            return result;
        }

        public IEnumerable<Toy> GetWantedToys()
        {
            var result = _context.Toys
                         .Include(i => i.Category)
                         .Include(i => i.Producer)
                         .Include(i => i.Gallery)
                         .Where(i => !i.InCollection)
                         .OrderBy(i => i.Name)
                         .ToList();
            return result;
        }

        public IEnumerable<Toy> GetWantedToysByCategory(int categoryId)
        {
            var result = _context.Toys
                         .Include(i => i.Category)
                         .Include(i => i.Producer)
                         .Include(i => i.Gallery)
                         .Where(i => !i.InCollection && i.Category.Id == categoryId)
                         .OrderBy(i => i.Name)
                         .ToList();
            return result;
        }

        public void DeleteToy(int toyId)
        {
            Toy toy = _context.Toys.Include(x => x.Gallery).SingleOrDefault(p => p.ToyID == toyId);
            _context.Toys.Remove(toy);
        }

        public void InsertToy(Toy toy)
        {
            _context.Toys.Add(toy);
        }

        public void UpdateToy(Toy toy)
        {
            _context.Entry(toy).State = EntityState.Modified;
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
