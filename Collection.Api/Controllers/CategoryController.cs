using System.Linq;
using System.Threading.Tasks;
using Collection.Entity.Entity.Common;
using Collection.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Collection.Api.Controllers
{
    public class CategoryController : ApiControllerBase
    {
        private readonly ICategoryService _categoryService;
        //private readonly ILogger<CategoryService> _logger;

        public CategoryController(ICategoryService categoryService)//, ILogger<CategoryService> logger)
        {
            _categoryService = categoryService;
            //_logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryService.GetAllAsync();
            //_logger.LogInformation($"Calling method GET. Total categories: {categories.Count()}.");
            return Json(categories);
        }

        [HttpGet("{name}/{page?}")]
        public async Task<IActionResult> Get(string name, int page = 1)
        {
            await Task.CompletedTask;
            return Json($"Call Get Category '{name}', page: {page}.");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Category model)
        {
            await _categoryService.AddAsync(model);
            return NoContent();
            //return Json($"Called Category POST. Id: {model.CategoryId} - name: '{model.Name}'");
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Category model)
        {
            await _categoryService.UpdateAsync(model);
            return NoContent();
            //return Json($"Called Category PUT. Id: {model.CategoryId} - name: '{model.Name}'");
        }
    }
}