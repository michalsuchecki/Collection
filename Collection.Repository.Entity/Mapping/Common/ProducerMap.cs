using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Collection.Entity.Common;

namespace Collection.Repository.Entity.Mapping
{
    public class ProducerMap : BaseMap<Producer>
    {
        public override void Configure(EntityTypeBuilder<Producer> builder)
        {
            builder.ToTable("Producer");
            builder.HasKey(x => x.ProducerId);
            builder.Property(x=> x.Name).HasMaxLength(50);
            builder.Property(x=> x.Url).HasMaxLength(200);

            base.Configure(builder);
        } 
    }
}