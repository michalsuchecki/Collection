using Collection.Entity.Entity;

namespace Collection.Entity.Entity.Common
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
