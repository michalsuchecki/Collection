using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Collection.Entity.Item;

namespace Collection.Repository.Entity.Mapping
{
    public class ItemRarityMap : BaseMap<ItemRarity>
    {
        public override void Configure(EntityTypeBuilder<ItemRarity> builder)
        {
            builder.ToTable("ItemRarity");
            builder.HasKey(x => x.ItemRarityId);
            builder.Property(x=> x.Name).HasMaxLength(50);

            base.Configure(builder);
        } 
    }
}