using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Collection.Models
{
    public class Producer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string URL { get; set; }
    }
}
