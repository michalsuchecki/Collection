using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyInflatables.Models;
using Microsoft.EntityFrameworkCore;

namespace MyInflatables.Repositories
{
    public class ProducerRepository : IProducerRepository, IDisposable
    {
        private ToyContext _context;

        public ProducerRepository(ToyContext context)
        {
            _context = context;
        }

        public IEnumerable<Producer> GetProducers()
        {
            return _context.Producers
                           .OrderBy(o => o.Name)
                           .ToList();
        }

        public Producer GetProducerByID(int Id)
        {
            return _context.Producers.Find(Id);
        }

        public void InsertProducer(Producer producer)
        {
            _context.Producers.Add(producer);
        }

        public void UpdateProducer(Producer producer)
        {
            _context.Entry(producer).State = EntityState.Modified;
        }

        public void DeleteProducer(int Id)
        {
            var producer = _context.Producers.Find(Id);
            _context.Producers.Remove(producer);
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
