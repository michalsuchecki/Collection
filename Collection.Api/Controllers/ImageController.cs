using System.Threading.Tasks;
using AutoMapper;
using Collection.Entity.Item;
using Collection.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Collection.Api.Controllers
{
    public class ImageController : ApiControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
        
            var images = await _imageService.BrowseAsync(-1);
            return Json(images);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
        
            var images = await _imageService.BrowseAsync(id);
            return Json(images);
        }

        [HttpGet("item/{itemId}")]
        public async Task<IActionResult> ItemImage(int itemId)
        {
            var item = new Item(){
                ItemId = itemId,
            };


            var images = await _imageService.GetItemImages(item);
            return Json(images);
        }
    }
}