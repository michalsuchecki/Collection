using Collection.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collection.Repositories
{
    public interface IGalleryRepository
    {
        IEnumerable<Gallery> GetAllImages();
        Gallery GetImageById(int id);
        Gallery GetImageByName(string name);
        IEnumerable<Gallery> GetImagesForToy(Toy toy);
        void AddImage(Gallery gallery);
        void RemoveImageById(int id);
        void RemoveImageByName(string name);
        void UpdateImage(Gallery gallery);

        void Save();
    }
}
