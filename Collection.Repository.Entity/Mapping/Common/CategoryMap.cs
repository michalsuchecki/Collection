using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Collection.Entity.Common;

namespace Collection.Repository.Entity.Mapping
{
    public class CategoryMap : BaseMap<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(x => x.CategoryId);
            builder.Property(x=> x.Name).HasMaxLength(50);
            builder.Property(x=> x.Level).HasDefaultValue(1);

            base.Configure(builder);
        } 
    }
}