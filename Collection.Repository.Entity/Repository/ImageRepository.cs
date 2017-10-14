using Collection.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Collection.Core.Domain;
using Collection.Repository.Entity.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Collection.Repository.Entity.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly IDBContext _context;

        public ImageRepository(IDBContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Image image)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Image>> GetAllAsync()
        {
            return await _context.GetImages().ToListAsync();
        }

        public async Task<Image> GetImageAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Image> GetImagesAsync(Item item)
        {
            //return await _context.GetImages().Where(x => x.Item.ItemId == item.ItemId).To
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Image image)
        {
            throw new NotImplementedException();
        }
    }
}
