using System.Collections.Generic;

namespace Collection.Core.Domain
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Index { get; set; }
        public Category Category { get; set; }
        public Producer Producer { get; set; }
        public bool InCollection { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
