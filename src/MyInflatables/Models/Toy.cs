using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyInflatables.Models
{
    public enum ToyStatus
    {

        Wanted,
        AlreadyHave
    };

    public class Toy
    {
        public int ToyID { get; set; }

        [Required]
        public string Name { get; set; }

        [MaxLength(10)]
        public string Index { get; set; }

        public Category Category { get; set; }

        public Producer Producer { get; set; }

        public ToyStatus Status { get; set; }

        public ICollection<Gallery> Gallery { get; set; }
    }
}
