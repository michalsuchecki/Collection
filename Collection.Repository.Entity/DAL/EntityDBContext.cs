using Microsoft.EntityFrameworkCore;
using Collection.Entity.Common;
using Collection.Entity.Blog;
using Collection.Entity.Item;
using Collection.Entity.User;
using System.Linq;
using System.Threading.Tasks;

namespace Collection.Repository.Entity.DAL
{
    public class EntityDBContext : DbContext
    {
        private readonly string _connectionString;
        public EntityDBContext(DbContextOptions<EntityDBContext> options) : this(options, "Server=(localdb)\\MSSQLLocalDB;Database=Collection;Trusted_Connection=True;MultipleActiveResultSets=true")
        {
        }

        public EntityDBContext(DbContextOptions<EntityDBContext> options, string connectionString) : base(options)
        {
            _connectionString = connectionString;
            Database.EnsureCreated();
        }

        protected override void  OnModelCreating(ModelBuilder builder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(_connectionString);
            builder.EnableSensitiveDataLogging();
            base.OnConfiguring(builder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<ItemImage> Images { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
