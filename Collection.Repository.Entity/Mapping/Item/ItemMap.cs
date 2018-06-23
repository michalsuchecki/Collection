using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Collection.Entity.Item;

namespace Collection.Repository.Entity.Mapping
{
    public class ItemMap : BaseMap<Item>
    {
        public override void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");
            builder.HasKey(x => x.CategoryId);
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Index).HasMaxLength(100);

            base.Configure(builder);
        }
    }
}
