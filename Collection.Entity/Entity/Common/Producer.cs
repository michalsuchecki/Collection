using Collection.Entity.Entity;

namespace Collection.Entity.Entity.Common
{
    public class Producer : IEntity
    {
        public int ProducerId { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
    }
}
