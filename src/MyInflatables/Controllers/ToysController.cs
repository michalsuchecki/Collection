﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyInflatables.Models;
using MyInflatables.Repositories;
using MyInflatables.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyInflatables.Helpers;
using Microsoft.AspNetCore.Hosting;

namespace MyInflatables.Controllers
{
    public class ToysController : Controller
    {
        private ToyContext _context;
        private IToyRepository _toyRepository;
        private IProducerRepository _producerRepository;
        private ICategoryRepository _categoryRepository;
        private IHostingEnvironment _environment;
        private IGalleryRepository _galleryRepository;

        public object ImageHelpers { get; private set; }

        public ToysController(IToyRepository toyRepository, IProducerRepository producerRepository, ICategoryRepository categoryRepository,
            IGalleryRepository galleryRepository, IHostingEnvironment environment, ToyContext context)
        {
            _toyRepository = toyRepository;
            _producerRepository = producerRepository;
            _categoryRepository = categoryRepository;
            _galleryRepository = galleryRepository;
            _environment = environment;
            _context = context;
        }

        public IActionResult Collection(int? Category, string SortBy, ToyListViewModel model)
        {
            model.Categories = FormHelper.GetFormCategories(_categoryRepository.GetCategories());
            model.Sort = FormHelper.GetFormSortBy();

            if (Category != null && Category != 0)
            {
                model.Toys = _toyRepository.GetMyToysByCategory(Category.Value);

            }
            else
            {
                model.Toys = _toyRepository.GetMyToys();
            }

            if (!String.IsNullOrEmpty(SortBy))
            {
                FormHelper.SortBy sort = (FormHelper.SortBy)Enum.Parse(typeof(FormHelper.SortBy), SortBy);

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

            return View("Index", model);
        }

        public IActionResult Wanted(int? Category, string SortBy, ToyListViewModel model)
        {
            model.Categories = FormHelper.GetFormCategories(_categoryRepository.GetCategories());
            model.Sort = FormHelper.GetFormSortBy();

            if (Category != null && Category != 0)
            {
                model.Toys = _toyRepository.GetWantedToysByCategory(Category.Value);

            }
            else
            {
                model.Toys = _toyRepository.GetWantedToys();
            }

            if (!String.IsNullOrEmpty(SortBy))
            {
                FormHelper.SortBy sort = (FormHelper.SortBy)Enum.Parse(typeof(FormHelper.SortBy), SortBy);

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

            return View("Index", model);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction("collection");

            var toy = _toyRepository.GetToyByID(id.Value);
            return View(toy);
        }

        public IActionResult AddImage(int? ToyId)
        {
            return RedirectToAction("Details", ToyId);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new ToyAddViewModel();
            model.Producers = _producerRepository.GetProducers().Select(s => new SelectListItem() { Text = s.Name, Value = s.Id.ToString() });
            model.Categories = _categoryRepository.GetCategories().Select(s => new SelectListItem() { Text = s.Name, Value = s.Id.ToString() });
            model.ToyStatus = FormHelper.GetFormToyStatus();
            model.Toy = new Toy();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ToyAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Toy.Category = _categoryRepository.GetCategoryByID(model.CategoryId);
                model.Toy.Producer = _producerRepository.GetProducerByID(model.ProducerId);
                model.Toy.Status = (ToyStatus)model.StatusId;

                _toyRepository.InsertToy(model.Toy);
                _toyRepository.Save();

                if (model.Images != null)
                {
                    var helper = new ImageHelper(_environment);
                    foreach (var image in model.Images)
                    {

                        var name = helper.AddImage(image);
                        var gallery = new Gallery() { FileName = name, Toy = model.Toy };
                        _galleryRepository.InsertGallery(gallery);
                    }
                    _galleryRepository.Save();
                }

                switch (model.Toy.Status)
                {
                    case ToyStatus.Wanted:
                        return RedirectToAction("wanted");
                    case ToyStatus.AlreadyHave:
                    default:
                        return RedirectToAction("collection");
                }
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult Remove(int id)
        {
            var toy = _toyRepository.GetToyByID(id);
            var images = _galleryRepository.GetGalleryForToy(toy);
            var helper = new ImageHelper(_environment);

            foreach (var image in images)
            {
                helper.RemoveImage(image.FileName);
            }

            _toyRepository.DeleteToy(id);
            _toyRepository.Save();

            switch (toy.Status)
            {
                case ToyStatus.Wanted:
                    return RedirectToAction("wanted");
                case ToyStatus.AlreadyHave:
                default:
                    return RedirectToAction("collection");
            }
        }


        protected override void Dispose(bool disposing)
        {
            _toyRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
