﻿using Collection.Infrastructure.DTO;
using Collection.Infrastructure.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Collection.Infrastructure.Services
{
    public interface IItemService : IServices
    {
        Task<ItemDto> GetAsync(int id);
        Task<IEnumerable<ItemDto>> GetAllAsync();
        Task<IEnumerable<ItemDto>> GetFilteredAsync(ItemFilter filter);
    }
}
