using Collection.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Collection.Entity.Item;
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

        public Task<ItemImage> GetById(bool readOnly = false)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<ItemImage>> List(bool readOnly = false)
        {
            throw new NotImplementedException();
        }

        public Task<ItemImage> Insert(ItemImage entity, bool forceSave = true)
        {
            throw new NotImplementedException();
        }

        public Task<ItemImage> Update(ItemImage entity, bool forceSave = true)
        {
            throw new NotImplementedException();
        }
        public Task Delete(ItemImage entity, bool forceSave = true)
        {
            throw new NotImplementedException();
        }
    }
}
