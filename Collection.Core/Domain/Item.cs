using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Collection.Core.Domain
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Index { get; set; }
        public Producer Category { get; set; }
        public Producer Producer { get; set; }
        public bool InCollection { get; set; }
        public ICollection<Producer> Gallery { get; set; }
    }
}
