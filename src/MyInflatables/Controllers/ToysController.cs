using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyInflatables.Models;
using MyInflatables.Repositories;
using MyInflatables.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyInflatables.Controllers
{
    public class ToysController : Controller
    {
        private ToyContext _context;
        private IToyRepository _toyRepository;
        private IProducerRepository _producerRepository;
        private ICategoryRepository _categoryRepository;

        public ToysController(IToyRepository toyRepository, IProducerRepository producerRepository, ICategoryRepository categoryRepository, ToyContext context)
        {
            _toyRepository = toyRepository;
            _producerRepository = producerRepository;
            _categoryRepository = categoryRepository;
            _context = context;
        }
        public IActionResult Index()
        {
            var toys = _toyRepository.GetToys();
            return View(toys);
        }
        [Route("/toys/{id}")]
        public IActionResult Details(int id)
        {
            var toy = _toyRepository.GetToyByID(id);
            return View(toy);
        }

        [Route("/toys/create")]
        [HttpGet]
        public IActionResult Create()
        {
            var model = new ToyAddViewModel();
            model.Producers = _producerRepository.GetProducers().Select(s => new SelectListItem() { Text = s.Name, Value = s.Id.ToString() });
            model.Categories = _categoryRepository.GetCategories().Select(s => new SelectListItem() { Text = s.Name, Value = s.Id.ToString() });
            model.Toy = new Toy();
            return View(model);
        }
        [Route("/toys/create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ToyAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = _context.Categories.Where(s => s.Id == model.CategoryId).SingleOrDefault();
                var producer = _context.Producers.Where(s => s.Id == model.ProducerId).SingleOrDefault();

                model.Toy.Category = _categoryRepository.GetCategoryByID(model.CategoryId);
                model.Toy.Producer = _producerRepository.GetProducerByID(model.ProducerId);

                _toyRepository.InsertToy(model.Toy);
                _toyRepository.Save();

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult Remove(int id)
        {
            _toyRepository.DeleteToy(id);
            _toyRepository.Save();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            _toyRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
