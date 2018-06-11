using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.Entity.Entity.Common
{
    public class Category : EntityBase
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int? ParentId { get; set; }
    }
}
