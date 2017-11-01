using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Collection.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Collection.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMailService _mailService;

        public HomeController(IMailService mailService)
        {
            _mailService = mailService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMessage(string name, string topic, string message, string email)
        {
            if(ModelState.IsValid)
            {
                await _mailService.SendEmail(message, topic, name, email);
            }
            return RedirectToAction("About", "Home");
        }


    }
}
