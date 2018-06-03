using AutoMapper;
using Collection.Entity.Entity.Item;
using Collection.Entity.Entity.Common;
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
                c.CreateMap<Image, ImageThumbDto>();
                c.CreateMap<Category, CategoryDto>();
                
            });

            return mapper.CreateMapper();
        }
    }
}
