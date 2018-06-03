using System.Collections.Generic;
using System.Threading.Tasks;
using Collection.Entity.Entity.Item;
using Collection.Infrastructure.DTO;

namespace Collection.Infrastructure.Services
{
    public interface IImageService
    {
        Task<ImageDto> GetAsync(int id);
        Task<ImageDto> GetAsync(string name);
        Task<IEnumerable<ImageThumbDto>> BrowseAsync(int toyId);
        Task<IEnumerable<ImageDto>> GetItemImages(Item item);
        Task AddAsync();
        Task UpdateAsync();
        Task DeleteAsync();
    }
}