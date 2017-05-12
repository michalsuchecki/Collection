using Microsoft.AspNetCore.Mvc.Rendering;
using Collection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Collection.Infrastructure;

namespace Collection.ViewModels
{
    public class ToyListViewModel
    {
        public int SortBy { get; set; }
        public int Category { get; set; }
        public IEnumerable<SelectListItem> Sort { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public PaginatedList<Toy> Toys { get; set; }
    }
}
