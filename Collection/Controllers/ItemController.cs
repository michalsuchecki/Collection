using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Collection.Models;
using Collection.ViewModels;
using Collection.Helpers;
using Microsoft.AspNetCore.Hosting;

namespace Collection.Controllers
{
    public class ItemController : Controller
    {
        private readonly ToyContext _context;
        private readonly IHostingEnvironment _environment;

        public ItemController(IHostingEnvironment environment, ToyContext context)
        {
            _environment = environment;
            _context = context;
        }

        // GET: Item
        public async Task<IActionResult> Index()
        {
            return View(await _context.Toys
                .Include(m => m.Producer)
                .Include(m => m.Category)
                .ToListAsync());
        }

        // GET: Item/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toy = await _context.Toys
                .SingleOrDefaultAsync(m => m.ToyID == id);
            if (toy == null)
            {
                return NotFound();
            }

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
        public async Task<IActionResult> Create(ToyViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Toy.Producer = await _context.Producers.SingleOrDefaultAsync(s => s.Id == model.Producer);
                model.Toy.Category = await _context.Categories.SingleOrDefaultAsync(s => s.Id == model.Category);

                _context.Add(model.Toy);

                if (model.Images != null)
                {
                    var helper = new ImageHelper(_environment);

                    foreach (var image in model.Images)
                    {
                        var imageName = helper.AddImage(image);
                        var gallery = new Gallery() { FileName = imageName, Toy = model.Toy };
                        _context.Add(gallery);
                    }
                }

                await _context.SaveChangesAsync();
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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var _toy = await _context.Toys
                                .Include(m => m.Producer)
                                .Include(m => m.Category)
                                .Include(m => m.Gallery)
                                .SingleOrDefaultAsync(m => m.ToyID == id);

            var model = new ToyViewModel()
            {
                Toy = _toy,
                Producers = FormHelper.GetFormProducers(_context.Producers.ToArray()),
                Categories = FormHelper.GetFormCategories(_context.Categories.ToArray()),
                Producer = _toy.Producer.Id,
                Category = _toy.Category.Id,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ToyViewModel model)
        {
            if (id != model.Toy.ToyID) return NotFound();

            if (ModelState.IsValid)
            {
                model.Toy.Producer = await _context.Producers.SingleOrDefaultAsync(s => s.Id == model.Producer);
                model.Toy.Category = await _context.Categories.SingleOrDefaultAsync(s => s.Id == model.Category);

                _context.Update(model.Toy);

                if (model.Images != null)
                {
                    var helper = new ImageHelper(_environment);

                    foreach (var image in model.Images)
                    {
                        var imageName = helper.AddImage(image);
                        var gallery = new Gallery() { FileName = imageName, Toy = model.Toy };
                        _context.Add(gallery);
                    }
                }

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Item/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toy = await _context.Toys
                .SingleOrDefaultAsync(m => m.ToyID == id);
            if (toy == null)
            {
                return NotFound();
            }

            return View(toy);
        }

        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toy = await _context.Toys.SingleOrDefaultAsync(m => m.ToyID == id);
            _context.Toys.Remove(toy);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ToyExists(int id)
        {
            return _context.Toys.Any(e => e.ToyID == id);
        }

        [HttpGet]
        [Route("delete/image/{image?}")]
        public async Task<IActionResult> DeleteImage(string image, string id)
        {
            id = (String)TempData["id"] ?? String.Empty;

            var record = _context.Gallery.Where(m => m.FileName == image).FirstOrDefault();
            if (record != null)
            {
               _context.Remove(record);
               await _context.SaveChangesAsync();
            }

            var helper = new ImageHelper(_environment);
            helper.RemoveImage(image);

            if (String.IsNullOrEmpty(id))
            {
                return View("Index");
            }
            else
            {
                return RedirectToAction("edit", new { id = id });
            }

        }
    }
}
