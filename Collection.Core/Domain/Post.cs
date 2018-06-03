using System;

namespace Collection.Core.Domain
{
    public class Post : IEntity
    {
        public int PostId { get; set; }
        public string Topic { get; set; }
        public string Message { get; set; }
        public DateTime PublishDate { get; set; }
        public User Author { get; set; }
    }
}
