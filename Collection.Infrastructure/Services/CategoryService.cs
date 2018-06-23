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

    }
}