using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Collection.Models;

namespace Collection.Views
{
    [Route("panel")]
    [Authorize(Roles = "Administrator")]
    public class ProducersController : Controller
    {
        private readonly ToyContext _context;

        public ProducersController(ToyContext context)
        {
            _context = context;    
        }

        [Route("producers")]
        public IActionResult Index()
        {
            return View(_context.Producers.ToList());
        }

        [Route("producers/add")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("producers/add")]
        public IActionResult Create(Producer producer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producer);
        }

        [Route("producers/edit/{id?}")]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var producer = _context.Producers.SingleOrDefault(m => m.Id == id);
            if (producer == null) return NotFound();
            return View(producer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("producers/edit/{id?}")]
        public IActionResult Edit(int id, Producer producer)
        {
            if (id != producer.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(producer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producer);
        }

        [Route("producers/delete/{id?}")]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var producer = _context.Producers.SingleOrDefault(m => m.Id == id);
            if (producer == null) return NotFound();
            return View(producer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("producers/delete/{id?}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var producer = _context.Producers.SingleOrDefault(m => m.Id == id);
            _context.Producers.Remove(producer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
