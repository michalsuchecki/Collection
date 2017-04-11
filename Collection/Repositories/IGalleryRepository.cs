using Collection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collection.Repositories
{
    public interface IGalleryRepository : IDisposable
    {
        IEnumerable<Gallery> GetGalleries();
        Gallery GetGalleryByID(int id);
        IEnumerable<Gallery> GetGalleryForToy(Toy toy);
        void InsertGallery(Gallery gallery);
        void DeleteGallery(int id);
        void UpdateGallery(Gallery gallery);
        void Save();
    }
}
