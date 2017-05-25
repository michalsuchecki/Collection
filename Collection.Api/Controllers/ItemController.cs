using Collection.Infrastructure.Commands;
using Collection.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Collection.Api.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IItemService _itemService;

        public ItemController(ICommandDispatcher commandDispatcher,
                              IItemService itemService)
        {
            _commandDispatcher = commandDispatcher;
            _itemService = itemService;
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id != null)
            {
                var item = await _itemService.GetAsync(id.Value);
                return Json(item);
            }
            return NotFound();
        }
    }
}
