using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyInflatables.Models;
using Microsoft.EntityFrameworkCore;

namespace MyInflatables.Repositories
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
            return _context.Toys.Find(toyId);
            // return _context.Toys.Where(s => s.ToyID == toyId).SingleOrDefault();
        }

        public IEnumerable<Toy> GetToys()
        {
            return _context.Toys.ToList();
        }

        public void DeleteToy(int toyId)
        {
            Toy toy = _context.Toys.Find(toyId);
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
