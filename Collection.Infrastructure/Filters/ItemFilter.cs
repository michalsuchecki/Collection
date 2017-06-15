using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.Infrastructure.Filters
{
    public enum DisplayAs
    {
        Collection,
        Wanted
    };

    public enum ShowAs
    {
        List,
        Gallery
    };

    public class ItemFilter
    {
        public string SearchString { get; set; }
        public DisplayAs DisplayAs { get; set; }
        public ShowAs ShowAs { get; set; }
        public int Category { get; set; }
        public int Producer { get; set; }
        public int Page { get; set; } = 1;
    }
}
