namespace Collection.Entity.Entity.Item
{
    public class Image : IEntity
    {
        public int ImageId { get; set; }
        public string FileName { get; set; }
        public Item Item { get; set; }
    }
}
