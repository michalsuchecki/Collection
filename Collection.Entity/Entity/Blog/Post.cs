using System;
using Collection.Entity.Entity.User;

namespace Collection.Entity.Entity.Blog
{
    public class Post : IEntity
    {
        public int PostId { get; set; }
        public string Topic { get; set; }
        public string Message { get; set; }
        public DateTime PublishDate { get; set; }
        public Collection.Entity.Entity.User.User Author { get; set; }
    }
}
