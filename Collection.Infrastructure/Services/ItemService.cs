using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Collection.Infrastructure.DTO;
using Collection.Core.Repositories;
using AutoMapper;
using Collection.Core.Domain;

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
        public async Task<ItemDto> GetAsync(int id)
        {
            var item = await _itemRepository.GetItemAsync(id);
            return _mapper.Map<Item,ItemDto>(item);
        }
    }
}
