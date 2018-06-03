using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Collection.Entity.Entity.Common;
using Collection.Infrastructure.DTO;
using Collection.Core.Repositories;
using AutoMapper;

namespace Collection.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _repository.BrowseAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<Category> GetAsync(string name)
        {
            return await _repository.GetAsync(name);
        }

        public async Task<IEnumerable<ItemDto>> GetItemsAsync(string name)
        {
            var category = _repository.GetAsync(name);
            await Task.CompletedTask;
            throw new System.NotImplementedException();
        }

        public async Task AddAsync(Category category)
        {
            await Task.CompletedTask;
            throw new System.NotImplementedException();
        }

        public async Task UpdateAsync(Category category)
        {
            await Task.CompletedTask;
            throw new System.NotImplementedException();
        }
    }
}