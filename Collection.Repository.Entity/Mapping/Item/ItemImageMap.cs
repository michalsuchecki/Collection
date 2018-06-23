using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Collection.Entity.Item;

namespace Collection.Repository.Entity.Mapping
{
    public class ItemImageMap : BaseMap<ItemImage>
    {
        public override void Configure(EntityTypeBuilder<ItemImage> builder)
        {
            builder.ToTable("ItemImage");
            builder.HasKey(x => x.ItemImageId);

            base.Configure(builder);
        } 
    }
}