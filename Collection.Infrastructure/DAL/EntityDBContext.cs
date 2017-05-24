using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Collection.Core.Domain;

namespace Collection.Infrastructure.DAL
{
    class EntityDBContext : DbContext, IDBContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Collection_new;Trusted_Connection=True;MultipleActiveResultSets=true");
            builder.EnableSensitiveDataLogging();

            base.OnConfiguring(builder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
