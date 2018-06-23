using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Collection.Entity.Item;
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
    }
}