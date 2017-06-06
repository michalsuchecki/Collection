using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Collection.Services;

namespace Collection.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        [HttpGet]
        [Route("{page?}")]
        public IActionResult Index(int page = 1)
        {
            var posts = _blogService.GetMessages(page);
            return View(posts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPost(string id, string title, string message)
        {
            if(ModelState.IsValid)
            {
                await _blogService.PostMessage(title, message, new Guid(id));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemovePost(int id, string userId)
        {
            if(ModelState.IsValid)
            {
                await _blogService.RemovePost(id, new Guid(userId));
            }
            return RedirectToAction("Index");
        }
    }
}