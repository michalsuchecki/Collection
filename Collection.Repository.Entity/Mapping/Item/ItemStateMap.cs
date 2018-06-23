using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Collection.Entity.Item;

namespace Collection.Repository.Entity.Mapping
{
    public class ItemStateMap : BaseMap<ItemState>
    {
        public override void Configure(EntityTypeBuilder<ItemState> builder)
        {
            builder.ToTable("ItemState");
            builder.HasKey(x => x.ItemStateId);
            builder.Property(x => x.Name).HasMaxLength(50);

            base.Configure(builder);
        }
    }
}