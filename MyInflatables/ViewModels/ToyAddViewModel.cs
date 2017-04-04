 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyInflatables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyInflatables.ViewModels
{
    public class ToyAddViewModel
    {
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Producers { get; set; }
        public IEnumerable<SelectListItem> ToyStatus { get; set; }
        public ICollection<IFormFile> Images { get; set; }

        public int CategoryId { get; set; }
        public int ProducerId { get; set; }
        public Toy Toy { get; set; }
    }
}
