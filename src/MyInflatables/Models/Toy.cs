using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyInflatables.Models
{
    public class Toy
    {
        public int ToyID { get; set; }

        [Required]
        public string Name { get; set; }

        public Category Category { get; set; }

        public Producer Producer { get; set; }
    }
}
