using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Collection.Entity.Item;

namespace Collection.Repository.Entity.Mapping
{
    public class ItemDescriptionMap : BaseMap<ItemDescription>
    {
        public override void Configure(EntityTypeBuilder<ItemDescription> builder)
        {
            builder.ToTable("ItemDescription");
            builder.HasKey(x => x.ItemDescriptionId);

            base.Configure(builder);
        } 
    }
}