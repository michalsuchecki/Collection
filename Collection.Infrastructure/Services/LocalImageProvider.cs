using System.Collections.Generic;
using System.Threading.Tasks;
using Collection.Infrastructure.DTO;
using Collection.Infrastructure.Settings;

namespace Collection.Infrastructure.Services
{
    public class LocalImageProvider : IImageProvider
    {
        private readonly LocalImages _settings;

        public LocalImageProvider(LocalImages settings)
        {
            _settings = settings;
        }
        public async Task<IEnumerable<ImageThumbDto>> GetImagesAsync(IEnumerable<string> files)
        {
            IList<ImageThumbDto> images = new List<ImageThumbDto>();

            foreach(var file in files)
            {
                 var img = new ImageThumbDto()
                 {
                    Image = _settings.Source + file + ".jpg",
                    Thumb = _settings.Thumbs + file + ".jpg"
                 };
                 images.Add(img);
            }

            return await Task.FromResult(images);
        }
    }
}