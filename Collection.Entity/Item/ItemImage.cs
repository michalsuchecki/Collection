namespace Collection.Entity.Item
{
    public class ItemImage : EntityBase
    {
        public int ItemImageId { get; set; }
        public string Name { get; set; }
        public int ItemId { get; set; }
        public bool AsThumbnail { get; set; }
    }
}
