﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Collection.Infrastructure.DTO;
using Collection.Core.Repositories;
using Collection.Entity.Item;
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

    }
}
