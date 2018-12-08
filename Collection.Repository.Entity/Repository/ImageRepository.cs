using Collection.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Collection.Entity.Item;
using Collection.Repository.Entity.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Collection.Repository.Entity.Repository;

namespace Collection.Repository.Entity.Repository
{
    public class ImageRepository : Repository<ItemImage>, IImageRepository
    {
        public ImageRepository(EntityDBContext context) : base(context)
        {
        }

        public IEnumerable<ItemImage> GetItemImages(int itemId)
        {
            throw new NotImplementedException();
        }

        public ItemImage GetItemPreviewImage(int itemId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemImage> GetItemsImages(int[] itemIds)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemImage> GetItemsPreviewImages(int[] itemsIds)
        {
            throw new NotImplementedException();
        }
    }
}
