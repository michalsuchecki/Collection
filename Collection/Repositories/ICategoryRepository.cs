using Collection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collection.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int Id);
        void InsertCategory(Category category);
        void DeleteCategory(int Id);
        void UpdateCategory(Category category);

        void Save();
    }
}
