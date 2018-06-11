namespace Collection.Entity.Entity.Item
{
    public class Item : EntityBase
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public int? ItemDescriptionId { get; set; }
        public string Index { get; set; }
        public int? ProductionYear { get; set; }
        public int CategoryId { get; set; }
        public int ProducerId { get; set; }
        public int RarityId { get; set; }
        public decimal? MarketPrice { get; set; }
    }
}
