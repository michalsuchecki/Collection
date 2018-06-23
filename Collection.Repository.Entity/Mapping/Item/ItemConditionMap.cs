using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Collection.Entity.Item;

namespace Collection.Repository.Entity.Mapping
{
    public class ItemConditionMap : BaseMap<ItemCondition>
    {
        public override void Configure(EntityTypeBuilder<ItemCondition> builder)
        {
            builder.ToTable("ItemCondition");
            builder.HasKey(x => x.ItemConditionId);
            builder.Property(x=> x.Name).HasMaxLength(50);

            base.Configure(builder);
        } 
    }
}