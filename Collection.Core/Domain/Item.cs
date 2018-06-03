using Collection.Core.Enums;
using System.Collections.Generic;

namespace Collection.Core.Domain
{
    public class Item : IEntity
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Index { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public Producer Producer { get; set; }
        public Condition Condition { get; set; }
        public bool InCollection { get; set; }
        public bool IsDamaged { get; set; }
        public bool IsForSale { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
