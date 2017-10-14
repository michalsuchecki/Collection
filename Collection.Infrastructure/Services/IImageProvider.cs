using System.Collections.Generic;
using System.Threading.Tasks;
using Collection.Infrastructure.DTO;

namespace Collection.Infrastructure.Services
{
    public interface IImageProvider
    {
         Task<IEnumerable<ImageThumbDto>> GetImagesAsync(IEnumerable<string> files);
    }
}