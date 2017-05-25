using Collection.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Collection.Core.Domain;
using Collection.Repository.Entity.DAL;

namespace Collection.Repository.Entity.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly IDBContext _context;

        public ImageRepository(IDBContext context)
        {
            _context = context;
        }
        public Task AddAsync(Image image)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Image>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Image> GetImageAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Image> GetImagesAsync(Item item)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Image image)
        {
            throw new NotImplementedException();
        }
    }
}
