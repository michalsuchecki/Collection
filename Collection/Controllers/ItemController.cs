using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Collection.Models;
using Collection.ViewModels;
using Collection.Helpers;
using Microsoft.AspNetCore.Hosting;
using Collection.Repositories;
using System.Collections.Generic;

namespace Collection.Controllers
{
    public class ItemController : Controller
    {
        private readonly ToyContext _context;
        private readonly IHostingEnvironment _environment;
        private readonly IToyRepository _toyRepository;
        private readonly IProducerRepository _producerRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IGalleryRepository _galleryRepository;

        public ItemController(IToyRepository toyRepository,
            IProducerRepository producerRepository,
            ICategoryRepository categoryRepository,
            IGalleryRepository galleryRepository,
            IHostingEnvironment environment, ToyContext context)
        {
            _toyRepository = toyRepository;
            _producerRepository = producerRepository;
            _categoryRepository = categoryRepository;
            _galleryRepository = galleryRepository;
            _environment = environment;
            _context = context;
        }

        // GET: Item
        public IActionResult Index(ToyListViewModel model, string display, string search, string sortBy, int? filterBy)
        {
            model.Categories = FormHelper.GetFilterFormCategories(_categoryRepository.GetCategories());
            model.Sort = FormHelper.GetFormSortBy();

            if (!String.IsNullOrEmpty(search))
            {
                model.Toys = _toyRepository.GetToysContaining(search);
            }
            else
            {
                if (String.IsNullOrEmpty(display))
                {
                    model.Toys = _toyRepository.GetAllToys();
                }
                else
                {
                    switch (display)
                    {
                        case "collection":
                            model.Toys = _toyRepository.GetMyToys();
                            break;
                        case "wanted":
                            model.Toys = _toyRepository.GetWantedToys();
                            break;
                        default:
                            model.Toys = _toyRepository.GetAllToys();
                            break;
                    }
                }
            }

            if (filterBy != null && filterBy != 0)
            {
                model.Toys = model.Toys.Where(x => x.Category.Id == filterBy).ToList();
            }

            if (!String.IsNullOrEmpty(sortBy))
            {
                FormHelper.SortBy sort = (FormHelper.SortBy)Enum.Parse(typeof(FormHelper.SortBy), sortBy);

                switch (sort)
                {
                    default:
                    case FormHelper.SortBy.Name:
                        model.Toys = model.Toys.OrderBy(s => s.Name).ToList();
                        break;
                    case FormHelper.SortBy.Producer:
                        model.Toys = model.Toys.OrderBy(s => s.Producer.Name).ToList();
                        break;
                    case FormHelper.SortBy.Category:
                        model.Toys = model.Toys.OrderBy(s => s.Category.Name).ToList();
                        break;

                }
            }

            return View(model);
        }

        // GET: Item/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var toy = _toyRepository.GetToyById(id.Value);
            if (toy == null) return NotFound();

            return View(toy);
        }

        // GET: Item/Create
        public IActionResult Create()
        {
            var producers = FormHelper.GetFormProducers(_context.Producers.ToArray());
            var categories = FormHelper.GetFormCategories(_context.Categories.ToArray());

            var vm = new ToyViewModel()
            {
                Producers = producers,
                Categories = categories
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ToyViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Toy.Producer = _producerRepository.GetProducerByID(model.Producer);
                model.Toy.Category = _categoryRepository.GetCategoryById(model.Category);

                _toyRepository.AddToy(model.Toy);

                if (model.Images != null)
                {
                    var helper = new ImageHelper(_environment);

                    foreach (var image in model.Images)
                    {
                        var imageName = helper.AddImage(image);
                        var gallery = new Gallery() { FileName = imageName, Toy = model.Toy };

                        _galleryRepository.AddImage(gallery);
                    }
                }

                _toyRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                model.Categories = FormHelper.GetFormCategories(_context.Categories.ToArray());
                model.Producers = FormHelper.GetFormProducers(_context.Producers.ToArray());
            }
            return View(model);
        }

        // GET: Item/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var _toy = _toyRepository.GetToyById(id.Value);

            var model = new ToyViewModel()
            {
                Toy = _toy,
                Producers = FormHelper.GetFormProducers(_producerRepository.GetProducers()),
                Categories = FormHelper.GetFormCategories(_categoryRepository.GetCategories()),
                Producer = _toy.Producer.Id,
                Category = _toy.Category.Id,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ToyViewModel model)
        {
            if (id != model.Toy.ToyID) return NotFound();

            if (ModelState.IsValid)
            {
                model.Toy.Producer = _producerRepository.GetProducerByID(model.Producer);
                model.Toy.Category = _categoryRepository.GetCategoryById(model.Category);

                _context.Update(model.Toy);

                if (model.Images != null)
                {
                    var helper = new ImageHelper(_environment);

                    foreach (var image in model.Images)
                    {
                        var imageName = helper.AddImage(image);
                        var gallery = new Gallery() { FileName = imageName, Toy = model.Toy };

                        _galleryRepository.AddImage(gallery);
                    }
                }

                _toyRepository.Save();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Item/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var toy = _toyRepository.GetToyById(id.Value);
            if (toy == null) return NotFound();

            return View(toy);
        }

        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var toy = _toyRepository.GetToyById(id);

            if (toy != null)
            {
                var images = _galleryRepository.GetImagesForToy(toy);

                if (images != null)
                {
                    var helper = new ImageHelper(_environment);
                    foreach (var img in images)
                    {
                        helper.RemoveImage(img.FileName);
                    }
                }
            }

            _toyRepository.DeleteToy(id);
            _toyRepository.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("delete/image/{name?}")]
        public IActionResult DeleteImage(string name, string id)
        {
            id = (String)TempData["id"] ?? String.Empty;

            _galleryRepository.RemoveImageByName(name);
            _galleryRepository.Save();

            var helper = new ImageHelper(_environment);
            helper.RemoveImage(name);

            if (String.IsNullOrEmpty(id))
            {
                return View("Index");
            }
            else
            {
                return RedirectToAction("edit", new { id = id });
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
