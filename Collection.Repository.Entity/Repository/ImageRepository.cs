using Collection.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Collection.Entity.Item;
using Collection.Repository.Entity.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Collection.Repository.Entity.Repository;

namespace Collection.Repository.Entity.Repositories
{
    public class ImageRepository : Repository<ItemImage>, IImageRepository
    {
        public ImageRepository(EntityDBContext context) : base(context)
        {
        }
    }
}
