using AutoMapper;
using Collection.Core.Domain;
using Collection.Infrastructure.DTO;

namespace Collection.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            var mapper = new MapperConfiguration(c =>
            {
                c.CreateMap<Item, ItemDto>().ForMember(x => x.Images, m => m.MapFrom(src => src.Images));
                c.CreateMap<Image, ImageDto>();
                
            });

            return mapper.CreateMapper();
        }
    }
}
