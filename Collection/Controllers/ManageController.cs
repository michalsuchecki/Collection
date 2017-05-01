using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Collection.Repositories;
using Collection.Models;

namespace Collection.Controllers
{
    [Authorize]
    [Route("panel")]
    public class ManageController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProducerRepository _producerRepository;

        public ManageController(ICategoryRepository categoryRepository,
                                IProducerRepository producerRepository)
        {
            _categoryRepository = categoryRepository;
            _producerRepository = producerRepository;
        }

        
        public IActionResult Index()
        {
            return View();
        }

    //    public IActionResult Categories()
    //    {
    //        var categories = _categoryRepository.GetCategories();
    //        return View(categories);
    //    }

    //    public IActionResult CategoryRename(int? id)
    //    {
    //        return View();
    //    }

    //    public IActionResult CategoryRename(int? id, string name)
    //    {

    //        return View();
    //    }

    //    public IActionResult CategoryRemove(int? id)
    //    {
    //        return View();
    //    }

    //    public IActionResult Producers()
    //    {
    //        var producers = _producerRepository.GetProducers();
    //        return View(producers);
    //    }

    //    public IActionResult AddProducers(string name)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            if(!string.IsNullOrEmpty(name))
    //            {
    //                var exist = _producerRepository.GetProducers().Where(x => x.Name.ToLower() == name.ToLower()).Any();
    //                if(!exist)
    //                {
    //                    var producer = new Producer()
    //                    {
    //                        Name = name
    //                    };
    //                    _producerRepository.AddProducer(producer);
    //                    _producerRepository.Save();
    //                }
    //            }
    //        }
    //        return RedirectToAction("producers");
    //    }
    }
}