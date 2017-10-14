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
        private readonly EntityDBContext _context;

        public ImageRepository(EntityDBContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Image image)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Image>> GetAllAsync()
        {
            return await _context.Images.ToListAsync();
        }

        public async Task<Image> GetImageAsync(int id)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public async Task<Image> GetImagesAsync(Item item)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(int id)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Image image)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }
    }
}
