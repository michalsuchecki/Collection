using System.ComponentModel.DataAnnotations;

namespace Collection.Core
{
    public class Producer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string URL { get; set; }
    }
}
