using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Collection.Entity.User;

namespace Collection.Repository.Entity.Mapping
{
    public class UserItemMap : BaseMap<UserItem>
    {
        public override void Configure(EntityTypeBuilder<UserItem> builder)
        {
            builder.ToTable("UserItem");
            builder.HasKey(x => x.UserItemId);

            builder.Property(x => x.PriceBuy).HasDefaultValue(0);
            builder.Property(x => x.PriceSell).HasDefaultValue(0);
            builder.Property(x => x.ForSale).HasDefaultValue(false);

            base.Configure(builder);
        }
    }
}