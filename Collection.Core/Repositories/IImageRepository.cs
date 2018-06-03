﻿using Collection.Entity.Entity.Item;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collection.Core.Repositories
{
    public interface IImageRepository : IRepository<Image>
    {
        Task<Image> GetImageAsync(int id);
        Task<Image> GetImagesAsync(Item item);
        Task<IEnumerable<Image>> GetAllAsync();
        Task AddAsync(Image image);
        Task UpdateAsync(Image image);
        Task RemoveAsync(int id);
    }
}
