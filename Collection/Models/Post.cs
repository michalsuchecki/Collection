using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Collection.Models
{
    public class Post
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(255)]
        public string Topic { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
        [Required]
        public User Author { get; set; }
    }
}
