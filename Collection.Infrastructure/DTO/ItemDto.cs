
using Collection.Core.Domain;
using System.Collections.Generic;

namespace Collection.Infrastructure.DTO
{
    public class ItemDto
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Index { get; set; }
        public Category Category { get; set; }
        public Producer Producer { get; set; }
        public bool InCollection { get; set; }
        public ICollection<ImageDto> Images { get; set; }
    }
}
