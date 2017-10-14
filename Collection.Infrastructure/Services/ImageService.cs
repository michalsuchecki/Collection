using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Collection.Core.Domain;
using Collection.Core.Repositories;
using Collection.Infrastructure.DTO;

namespace Collection.Infrastructure.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _repository;
        private readonly IImageProvider _imageProvider;
        private readonly IMapper _mapper;

        public ImageService(IImageRepository repository, IImageProvider imageProvider, IMapper mapper)
        {
            _repository = repository;
            _imageProvider = imageProvider;
            _mapper = mapper;
        }
        public async Task AddAsync()
        {
            await Task.CompletedTask;
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<ImageThumbDto>> BrowseAsync(int toyId = -1)
        {
            if(toyId >= 0)
            {
                IList<Image> images = new List<Image>();
                var image = await _repository.GetImageAsync(toyId);
                images.Add(image);

                var filenames = images.Select(x => x.FileName);

                return await _imageProvider.GetImagesAsync(filenames);
            }
            else
            {
                var images = await _repository.GetAllAsync();
                var filenames = images.Select(x => x.FileName);

                return await _imageProvider.GetImagesAsync(filenames);

                //return _mapper.Map<IEnumerable<ImageThumbDto>>(images);
            }

        }


        public async Task<ImageDto> GetAsync(int id)
        {
            await Task.CompletedTask;
            throw new System.NotImplementedException();
        }

        public async Task<ImageDto> GetAsync(string name)
        {
            await Task.CompletedTask;
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<ImageDto>> GetItemImages(Item item)
        {
            var images = await _repository.GetImagesAsync(item);

            return _mapper.Map<IEnumerable<ImageDto>>(images);
            
        }

        public async Task UpdateAsync()
        {
            await Task.CompletedTask;
        }

        public async Task DeleteAsync()
        {
            await Task.CompletedTask;
        }

    }
}