using MyInflatables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyInflatables.Repositories
{
    public interface ICategoryRepository : IDisposable
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryByID(int Id);
        void InsertCategory(Category category);
        void DeleteCategory(int Id);
        void UpdateCategory(Category category);
        void Save();
    }
}
