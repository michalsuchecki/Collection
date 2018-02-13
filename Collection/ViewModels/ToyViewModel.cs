using Collection.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Collection.ViewModels
{
    public class ToyViewModel
    {
        public Toy Toy { get; set; }
        public int Producer { get; set; }
        public List<SelectListItem> Producers { get; set; }
        public int Category { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public int Condition { get; set; }
        public List<SelectListItem> Conditions { get; set; }
        public List<IFormFile> Images { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode=true)]
        [DataType(DataType.Date)] 
        public DateTime? PurchaseDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode=true)]
        [DataType(DataType.Date)] 
        public DateTime? SoldDate { get; set; }
    }
}
