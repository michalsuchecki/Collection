using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Collection.Core
{
    public class Toy
    {
        [Required]
        public int ToyID { get; set; }
        [Required]
        public string Name { get; set; }
        [MaxLength(16)]
        public string Index { get; set; }
        public Category Category { get; set; }
        public Producer Producer { get; set; }
        public bool InCollection { get; set; }
        public ICollection<Gallery> Gallery { get; set; }
    }
}
