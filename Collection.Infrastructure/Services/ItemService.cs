using System.Collections.Generic;
using System.Threading.Tasks;
using Collection.Infrastructure.DTO;
using Collection.Core.Repositories;
using Collection.Entity.Entity.Item;
using AutoMapper;
using Collection.Infrastructure.Filters;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IEnumerable<ItemDto>> GetFilteredAsync(ItemFilter filter)
        {
            var items = _itemRepository.GetAll();

            switch (filter.DisplayAs)
            {
                case DisplayAs.Wanted:
                    items = items.Where(x => !x.InCollection);
                    break;
                case DisplayAs.Collection:
                default:
                    items = items.Where(x => x.InCollection);
                    break;
            }

            if (!String.IsNullOrEmpty(filter.SearchString))
            {
                items = items.Where(x => x.Name.ToLower().Contains(filter.SearchString.ToLower()));
            }

            if(filter.Category != 0)
            {
                items = items.Where(x => x.Category.CategoryId == filter.Category);
            }
        
            if (filter.Producer != 0)
            {
                items = items.Where(x => x.Producer.ProducerId == filter.Producer);
            }

            // TODO 12 items per page -> take from settings

            if (filter.Page <= 0) filter.Page = 1;

            items = items.Skip((filter.Page - 1) * 12).Take(12);

            var result = await items.ToListAsync();

            return _mapper.Map<IEnumerable<Item>, IEnumerable<ItemDto>>(result);
        }
    }
}
