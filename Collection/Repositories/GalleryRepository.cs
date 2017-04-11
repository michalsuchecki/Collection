using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Collection.Models;

namespace Collection.Repositories
{
    public class GalleryRepository : IGalleryRepository, IDisposable
    {
        private ToyContext _context;

        public GalleryRepository(ToyContext context)
        {
            _context = context;
        }

        public IEnumerable<Gallery> GetGalleries()
        {
            return _context.Gallery.ToList();
        }

        public Gallery GetGalleryByID(int id)
        {
            return _context.Gallery.Find(id);
        }

        public IEnumerable<Gallery> GetGalleryForToy(Toy toy)
        {
            return _context.Gallery.Where(g => g.Toy == toy).ToList();
        }

        public void InsertGallery(Gallery gallery)
        {
            _context.Gallery.Add(gallery);
        }

        public void UpdateGallery(Gallery gallery)
        {
            throw new NotImplementedException();
        }

        public void DeleteGallery(int id)
        {
            throw new NotImplementedException();
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
