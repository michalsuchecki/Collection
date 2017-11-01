using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Collection.Models
{
    public class Toy
    {
        public int ToyID { get; set; }
        [Required]
        public string Name { get; set; }
        [MaxLength(10)]
        public string Index { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public Producer Producer { get; set; }
        public bool InCollection { get; set; }
        public ICollection<Gallery> Gallery { get; set; }
    }
}