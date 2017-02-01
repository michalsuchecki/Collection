using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyInflatables.Models
{
    public class Gallery
    {
        public int GalleryId { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public Toy Toy { get; set; }
    }
}
