using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyInflatables.Models;
using MyInflatables.Repositories;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MyInflatables.Controllers
{
    [Route("/[controller]")]
    public class ToysController : Controller
    {
        private IToyRepository _repository;

        public ToysController(IToyRepository repository)
        {
            _repository = repository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


    }
}
