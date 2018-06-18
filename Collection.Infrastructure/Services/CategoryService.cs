using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Collection.Entity.Common;
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
            var categories = _repository.List(true);
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<Category> GetAsync(string name)
        {
            //return await _repository.GetAsync(name);
            return null;
        }

        public async Task<IEnumerable<ItemDto>> GetItemsAsync(string name)
        {
            // var category = _repository.GetAsync(name);
            // await Task.CompletedTask;
            // throw new System.NotImplementedException();
            return null;
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