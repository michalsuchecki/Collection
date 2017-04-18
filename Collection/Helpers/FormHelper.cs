using Microsoft.AspNetCore.Mvc.Rendering;
using Collection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collection.Helpers
{
    public class FormHelper
    {
        public enum SortBy
        {
            Name,
            Producer,
            Category
        };

        public static IEnumerable<SelectListItem> GetFilterFormCategories(IEnumerable<Category> categories)
        {
            var SelectedList = GetFormCategories(categories);
            SelectedList.Insert(0, new SelectListItem() { Text = "All", Value = "0" });
            return SelectedList;
        }
        public static IEnumerable<SelectListItem> GetFilterFormProducers(IEnumerable<Producer> producers)
        {
            var SelectedList = GetFormProducers(producers);
            SelectedList.Insert(0,new SelectListItem() { Text = "All", Value = "0" });
            return SelectedList;
        }

        public static IEnumerable<SelectListItem> GetFormSortBy()
        {
            var sortList = Enum.GetValues(typeof(SortBy));
            var SelectedList = new List<SelectListItem>();

            foreach (var item in sortList)
            {
                SelectedList.Add(new SelectListItem() { Text = item.ToString(), Value = item.ToString() });
            }

            return SelectedList;
        }

        public static List<SelectListItem> GetFormProducers(IEnumerable<Producer> producers)
        {
            var SelectedList = new List<SelectListItem>();
            SelectedList.AddRange(producers.Select(s => new SelectListItem() { Text = s.Name, Value = s.Id.ToString() }));

            return SelectedList;
        }

        public static List<SelectListItem> GetFormCategories(IEnumerable<Category> categories)
        {
            var SelectedList = new List<SelectListItem>();
            SelectedList.AddRange(categories.Select(s => new SelectListItem() { Text = s.Name, Value = s.Id.ToString() }));

            return SelectedList;
        }
    }
}
