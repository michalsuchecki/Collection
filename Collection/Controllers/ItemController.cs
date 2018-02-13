using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Collection.Models;
using Collection.ViewModels;
using Collection.Helpers;
using Collection.Repositories;
using Collection.Infrastructure;


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
        //[HttpGet]
        public IActionResult Index(ToyListViewModel model, string showAs, string display, string search, string sortBy,
                                   int? filterBy, int? page)
        {
            model.Categories = FormHelper.GetFilterFormCategories(_categoryRepository.GetCategories());
            model.Sort = FormHelper.GetFormSortBy();

            ViewData["showAs"] = showAs;
            ViewData["search"] = search;
            ViewData["display"] = display;
            ViewData["filterBy"] = filterBy;
            ViewData["sortBy"] = sortBy;

            IQueryable<Toy> Toys;

            if (!String.IsNullOrEmpty(search))
            {
                page = 1;
                Toys = _toyRepository.GetToysContaining(search);
            }
            else
            {
                switch (display)
                {
                    case "wanted":
                        ViewBag.Section = "Wanted toys";
                        Toys = _toyRepository.GetWantedToys();
                        model.TotalPrice = Toys.Sum(x => x.Price);
                        break;
                    case "forsale":
                        ViewBag.Section = "Toys for sale";
                        Toys = _toyRepository.GetToysForSale();
                        model.TotalPrice = Toys.Sum(x => x.Price);
                        break;
                    case "sold":
                        ViewBag.Section = "My sold toys";
                        Toys = _toyRepository.GetMySoldToys();
                        model.TotalPrice = Toys.Sum(x => x.SoldPrice ?? 0);
                        break;
                    case "collection":
                    default:
                        ViewBag.Section = "My collection";
                        Toys = _toyRepository.GetMyToys();
                        model.TotalPrice = Toys.Sum(x => x.Price);
                        break;

                }
            }

            if (filterBy != null && filterBy != 0)
            {
                Toys = Toys.Where(x => x.Category.Id == filterBy);

                if (HttpContext.Request.Method == "POST")
                {
                    page = 1;
                }
            }

            if (!String.IsNullOrEmpty(sortBy))
            {
                FormHelper.SortBy sort = (FormHelper.SortBy)Enum.Parse(typeof(FormHelper.SortBy), sortBy);
                switch (sort)
                {
                    default:
                    case FormHelper.SortBy.Name:
                        Toys = Toys.OrderBy(s => s.Name);
                        break;
                    case FormHelper.SortBy.Producer:
                        Toys = Toys.OrderBy(s => s.Producer.Name);
                        break;
                    case FormHelper.SortBy.Category:
                        Toys = Toys.OrderBy(s => s.Category.Name);
                        break;
                }
                if (HttpContext.Request.Method == "POST")
                {
                    page = 1;
                }
            }

            ViewData["Page"] = page;
            ViewData["TotalItems"] = Toys.Count();

            page = (page - 1) ?? 0;

            model.Toys = new PaginatedList<Toy>(Toys, page.Value);
            //model.TotalPrice = Toys.Sum(x => x.Price);
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
                Categories = categories,
                Conditions = FormHelper.GetFormCondition()
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
                Conditions = FormHelper.GetFormCondition(),
                Condition = (int)_toy.Condition
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
                model.Toy.Condition = (Condition)model.Condition;

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
