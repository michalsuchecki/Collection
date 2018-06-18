using System;

namespace Collection.Entity.Blog
{
    public class Post : EntityBase
    {
        public int PostId { get; set; }
        public string Topic { get; set; }
        public string Message { get; set; }
        public DateTime PublishDate { get; set; }
        public Collection.Entity.User.User Author { get; set; }
    }
}
