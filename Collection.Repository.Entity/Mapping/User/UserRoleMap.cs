using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Collection.Entity.User;

namespace Collection.Repository.Entity.Mapping
{
    public class UserRoleMap : BaseMap<UserRole>
    {
        public override void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole");
            builder.HasKey(x => x.UserRoleId);
            builder.Property(x => x.Name).HasMaxLength(50);

            base.Configure(builder);
        }
    }
}
