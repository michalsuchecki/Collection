namespace Collection.Core.Domain
{
    public class Image
    {
        public int ImageId { get; set; }
        public string FileName { get; set; }
        public Item Item { get; set; }
    }
}
