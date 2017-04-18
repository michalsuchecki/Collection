using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Collection.Models;
using Microsoft.EntityFrameworkCore;

namespace Collection.Repositories
{
    public class GalleryRepository : IGalleryRepository, IDisposable
    {
        protected readonly ToyContext _context;

        public GalleryRepository(ToyContext context)
        {
            _context = context;
        }

        public IEnumerable<Gallery> GetAllImages()
        {
            return _context.Gallery.ToList();
        }

        public Gallery GetImageById(int id)
        {
            return _context.Gallery.Find(id);
        }

        public Gallery GetImageByName(string name)
        {
            return _context.Gallery.Where(m => m.FileName == name).FirstOrDefault();
        }

        public IEnumerable<Gallery> GetImagesForToy(Toy toy)
        {
            return _context.Gallery.Where(g => g.Toy == toy).ToList();
        }

        public void AddImage(Gallery gallery)
        {
            _context.Gallery.AddAsync(gallery);
        }

        public void RemoveImageByName(string name)
        {
            var image = GetImageByName(name);
            _context.Remove(image);
        }

        public void RemoveImageById(int id)
        {
            var image = GetImageById(id);
            _context.Remove(image);
        }

        public void UpdateImage(Gallery gallery)
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
