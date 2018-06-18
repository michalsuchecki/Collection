using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Collection.Entity.Common;
using Collection.Core.Repositories;
using Collection.Repository.Entity.DAL;
using Microsoft.EntityFrameworkCore;

namespace Collection.Repository.Entity.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public Task<Category> GetById(bool readOnly = false)
        {
            throw new System.NotImplementedException();
        }

        public Task<IQueryable<Category>> List(bool readOnly = false)
        {
            throw new System.NotImplementedException();
        }

        public Task<Category> Insert(Category entity, bool forceSave = true)
        {
            throw new System.NotImplementedException();
        }

        public Task<Category> Update(Category entity, bool forceSave = true)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(Category entity, bool forceSave = true)
        {
            throw new System.NotImplementedException();
        }

    }
}