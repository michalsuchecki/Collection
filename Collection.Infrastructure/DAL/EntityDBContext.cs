using Microsoft.EntityFrameworkCore;
using Collection.Core.Domain;

namespace Collection.Infrastructure.DAL
{
    class EntityDBContext : DbContext, IDBContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
