using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Collection.Entity.User;

namespace Collection.Repository.Entity.Mapping
{
    public class UserMap : BaseMap<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.Username).HasMaxLength(100);
            builder.Property(x => x.Password).HasMaxLength(100);
            builder.Property(x => x.Salt).HasMaxLength(32);
            builder.Property(x => x.Activation).HasMaxLength(32);

            base.Configure(builder);
        }
    }
}
