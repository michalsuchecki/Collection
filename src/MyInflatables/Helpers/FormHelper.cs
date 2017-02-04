using Microsoft.AspNetCore.Mvc.Rendering;
using MyInflatables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyInflatables.Helpers
{
    public class FormHelper
    {
        public static IEnumerable<SelectListItem> GetFormCategories(IEnumerable<Category> categories)
        {
            var SelectedList = new List<SelectListItem>();
            SelectedList.Add(new SelectListItem() { Text = "All", Value = "0" });
            SelectedList.AddRange(categories.Select(s => new SelectListItem() { Text = s.Name, Value = s.Id.ToString() }));

            return SelectedList;
        }
        public static IEnumerable<SelectListItem> GetFormProducers(IEnumerable<Producer> producers)
        {
            var SelectedList = new List<SelectListItem>();
            SelectedList.Add(new SelectListItem() { Text = "All", Value = "0" });
            SelectedList.AddRange(producers.Select(s => new SelectListItem() { Text = s.Name, Value = s.Id.ToString() }));

            return SelectedList;
        }
    }
}
