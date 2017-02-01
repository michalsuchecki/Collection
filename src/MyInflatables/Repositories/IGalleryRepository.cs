using MyInflatables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyInflatables.Repositories
{
    public interface IGalleryRepository : IDisposable
    {
        IEnumerable<Gallery> GetGalleries();
        Gallery GetGalleryByID(int id);
        void InsertGallery(Gallery gallery);
        void DeleteGallery(int id);
        void UpdateGallery(Gallery gallery);
        void Save();
    }
}
