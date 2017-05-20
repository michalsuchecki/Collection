using System.ComponentModel.DataAnnotations;

namespace Collection.Core
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
