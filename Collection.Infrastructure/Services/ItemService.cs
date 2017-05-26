using System.Collections.Generic;
using System.Threading.Tasks;
using Collection.Infrastructure.DTO;
using Collection.Core.Repositories;
using Collection.Core.Domain;
using AutoMapper;


namespace Collection.Infrastructure.Services
{
    class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ItemService(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemDto>> GetAllAsync()
        {
            var items = await _itemRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Item>, IEnumerable<ItemDto>>(items);
        }

        public async Task<ItemDto> GetAsync(int id)
        {
            var item = await _itemRepository.GetItemAsync(id);
            return _mapper.Map<Item,ItemDto>(item);
        }
    }
}
