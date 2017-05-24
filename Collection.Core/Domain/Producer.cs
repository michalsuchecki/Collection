using System.ComponentModel.DataAnnotations;

namespace Collection.Core.Domain
{
    public class Producer
    {
        public int ProducerId { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
    }
}
