using System.ComponentModel.DataAnnotations;

namespace Collection.Core
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
