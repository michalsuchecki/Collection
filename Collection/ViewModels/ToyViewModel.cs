using Collection.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Collection.ViewModels
{
    public class ToyViewModel
    {
        public Toy Toy { get; set; }

        public int Producer { get; set; }

        public List<SelectListItem> Producers { get; set; }

        public int Category { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public List<IFormFile> Images { get; set; }
    }
}
