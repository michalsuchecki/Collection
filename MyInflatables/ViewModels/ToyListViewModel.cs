using Microsoft.AspNetCore.Mvc.Rendering;
using MyInflatables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyInflatables.ViewModels
{
    public class ToyListViewModel
    {
        public int SortBy { get; set; }
        public int Category { get; set; }
        public IEnumerable<SelectListItem> Sort { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<Toy> Toys { get; set; }
    }
}
