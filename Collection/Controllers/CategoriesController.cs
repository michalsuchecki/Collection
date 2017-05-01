using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Collection.Repositories;
using Collection.Models;

namespace Collection.Views
{
    [Route("panel")]
    [Authorize(Roles = "Administrator")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [Route("categories")]
        public IActionResult Index()
        {
            var result = _categoryRepository.GetCategories();
            return View(result);
        }

        [Route("categories/add")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("categories/add")]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.AddCategory(category);
                _categoryRepository.Save();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [Route("categories/edit/{id?}")]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var category = _categoryRepository.GetCategoryById(id.Value);
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("categories/edit/{id?}")]
        public IActionResult Edit(int id, Category category)
        {
            if (id != category.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _categoryRepository.UpdateCategory(category);
                _categoryRepository.Save();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [Route("categories/delete/{id?}")]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var category = _categoryRepository.GetCategoryById(id.Value);
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("categories/delete/{id?}")]
        public IActionResult DeleteConfirmed(int id)
        {
            _categoryRepository.DeleteCategory(id);
            _categoryRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
