using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Collection.Models;
using Collection.Repositories;
using Collection.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Collection.Helpers;
using Microsoft.AspNetCore.Hosting;

namespace Collection.Controllers
{
    public class ToysController : Controller
    {
        //private ToyContext _context;
        //private IToyRepository _toyRepository;
        //private IProducerRepository _producerRepository;
        //private ICategoryRepository _categoryRepository;
        //private IHostingEnvironment _environment;
        //private IGalleryRepository _galleryRepository;

        //public object ImageHelpers { get; private set; }

        //public ToysController(IToyRepository toyRepository, IProducerRepository producerRepository, ICategoryRepository categoryRepository,
        //    IGalleryRepository galleryRepository, IHostingEnvironment environment, ToyContext context)
        //{
        //    _toyRepository = toyRepository;
        //    _producerRepository = producerRepository;
        //    _categoryRepository = categoryRepository;
        //    _galleryRepository = galleryRepository;
        //    _environment = environment;
        //    _context = context;
        //}

        //public async Task<IActionResult> Collection(int? Category, string SortBy, ToyListViewModel model)
        //{
        //    model.Categories = FormHelper.GetFilterFormCategories(_categoryRepository.GetCategories());
        //    model.Sort = FormHelper.GetFormSortBy();

        //    if (Category != null && Category != 0)
        //    {
        //        model.Toys = await _toyRepository.GetMyToysByCategory(Category.Value);
                
        //    }
        //    else
        //    {
        //        model.Toys = await _toyRepository.GetMyToys();
        //    }

        //    if (!String.IsNullOrEmpty(SortBy))
        //    {
        //        FormHelper.SortBy sort = (FormHelper.SortBy)Enum.Parse(typeof(FormHelper.SortBy), SortBy);

        //        switch (sort)
        //        {
        //            default:
        //            case FormHelper.SortBy.Name:
        //                model.Toys = model.Toys.OrderBy(s => s.Name).ToList();
        //                break;
        //            case FormHelper.SortBy.Producer:
        //                model.Toys = model.Toys.OrderBy(s => s.Producer.Name).ToList();
        //                break;
        //            case FormHelper.SortBy.Category:
        //                model.Toys = model.Toys.OrderBy(s => s.Category.Name).ToList();
        //                break;
        //        }
        //    }

        //    return View("Index", model);
        //}

        //public async Task<IActionResult> Wanted(int? Category, string SortBy, ToyListViewModel model)
        //{
        //    model.Categories = FormHelper.GetFilterFormCategories(_categoryRepository.GetCategories());
        //    model.Sort = FormHelper.GetFormSortBy();

        //    if (Category != null && Category != 0)
        //    {
        //        model.Toys = await _toyRepository.GetWantedToysByCategory(Category.Value);

        //    }
        //    else
        //    {
        //        model.Toys = await _toyRepository.GetWantedToys();
        //    }

        //    if (!String.IsNullOrEmpty(SortBy))
        //    {
        //        FormHelper.SortBy sort = (FormHelper.SortBy)Enum.Parse(typeof(FormHelper.SortBy), SortBy);

        //        switch (sort)
        //        {
        //            default:
        //            case FormHelper.SortBy.Name:
        //                model.Toys = model.Toys.OrderBy(s => s.Name).ToList();
        //                break;
        //            case FormHelper.SortBy.Producer:
        //                model.Toys = model.Toys.OrderBy(s => s.Producer.Name).ToList();
        //                break;
        //            case FormHelper.SortBy.Category:
        //                model.Toys = model.Toys.OrderBy(s => s.Category.Name).ToList();
        //                break;
        //        }
        //    }

        //    return View("Index", model);
        //}

        //public IActionResult Details(int? id)
        //{
        //    if (id == null)
        //        return RedirectToAction("collection");

        //    var toy = _toyRepository.GetToyById(id.Value);
        //    return View(toy);
        //}

        //public IActionResult AddImage(int? ToyId)
        //{
        //    return RedirectToAction("Details", ToyId);
        //}

        //[HttpGet]
        //public async Task<IActionResult> Create()
        //{
        //    var model = new ToyAddViewModel()
        //    {
        //        Producers = (await _producerRepository.GetProducers()).Select(s => new SelectListItem() { Text = s.Name, Value = s.Id.ToString() }),
        //        Categories = _categoryRepository.GetCategories().Select(s => new SelectListItem() { Text = s.Name, Value = s.Id.ToString() }),
        //        Toy = new Toy()
        //    };
        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(ToyAddViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        model.Toy.Category = _categoryRepository.GetCategoryById(model.CategoryId);
        //        model.Toy.Producer = _producerRepository.GetProducerByID(model.ProducerId);

        //        _toyRepository.InsertToy(model.Toy);
        //        _toyRepository.Save();

        //        if (model.Images != null)
        //        {
        //            var helper = new ImageHelper(_environment);
        //            foreach (var image in model.Images)
        //            {

        //                var name = helper.AddImage(image);
        //                var gallery = new Gallery() { FileName = name, Toy = model.Toy };
        //                _galleryRepository.InsertGallery(gallery);
        //            }
        //            _galleryRepository.Save();
        //        }

        //        return RedirectToAction(model.Toy.InCollection ? "collection" : "wanted");
        //    }
        //    else
        //    {
        //        return View(model);
        //    }
        //}

        //public async Task<IActionResult> Remove(int id)
        //{
        //    var toy = await _toyRepository.GetToyById(id);
        //    var images = _galleryRepository.GetGalleryForToy(toy);
        //    var helper = new ImageHelper(_environment);

        //    foreach (var image in images)
        //    {
        //        helper.RemoveImage(image.FileName);
        //    }

        //    _toyRepository.DeleteToy(id);
        //    _toyRepository.Save();

        //    return RedirectToAction(toy.InCollection ? "collection" : "wanted");
        //}

        //[HttpGet]
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id != null)
        //    {
        //        var toy = await _toyRepository.GetToyById(id.Value);
        //        var model = new ToyAddViewModel()
        //        {
        //            Toy = toy,
        //            Categories = _categoryRepository.GetCategories().Select(s => new SelectListItem() { Text = s.Name, Value = s.Id.ToString() }),
        //            Producers = (await _producerRepository.GetProducers()).Select(s => new SelectListItem() { Text = s.Name, Value = s.Id.ToString() }),
        //            ProducerId = toy.Producer.Id,
        //            CategoryId = toy.Category.Id,
        //        };

        //        return View(model);
        //    }

        //    return View("Index");
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(int? id, ToyAddViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // TODO: Adding Images
        //        model.Toy.Category = _categoryRepository.GetCategoryById(model.CategoryId);
        //        model.Toy.Producer = _producerRepository.GetProducerByID(model.ProducerId);
        //        _toyRepository.UpdateToy(model.Toy);
        //        _toyRepository.Save();

        //        return RedirectToAction(model.Toy.InCollection ? "collection" : "wanted");
        //    }
        //    else
        //    {
        //        return View(model);
        //    }
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    _toyRepository.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}
