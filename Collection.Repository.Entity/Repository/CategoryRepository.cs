using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Collection.Entity.Common;
using Collection.Core.Repositories;
using Collection.Repository.Entity.DAL;
using Microsoft.EntityFrameworkCore;

namespace Collection.Repository.Entity.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(EntityDBContext context) : base(context)
        {          
        }
    }
}