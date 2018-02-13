using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Collection.Models {
    public enum Condition {
        New,
        Used
    }
    public class Toy {
        public int ToyID { get; set; }

        [Required]
        public string Name { get; set; }

        [MaxLength (10)]
        public string Index { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public Producer Producer { get; set; }
        public bool InCollection { get; set; }
        public ICollection<Gallery> Gallery { get; set; }
        public Condition Condition { get; set; }
        public bool IsDamaged { get; set; }
        public bool ForSale { get; set; }
        public bool Sold { get; set; }
        public decimal? SoldPrice { get; set; }
        public DateTime? SoldDate { get; set; }
        public DateTime? PurchaseDate { get; set; }
    }
}