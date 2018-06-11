using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.Entity.Entity.Common
{
    public class Producer : EntityBase
    {
        public int ProducerId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
