using Microsoft.EntityFrameworkCore;
using Collection.Core.Domain;
using System.Linq;

namespace Collection.Repository.Entity.DAL
{
    public class EntityDBContext : DbContext, IDBContext
    {
        private readonly string _connectionString;

        public EntityDBContext() : this("Server=(localdb)\\MSSQLLocalDB;Database=Collection_new;Trusted_Connection=True;MultipleActiveResultSets=true")
        {

        }

        public EntityDBContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(_connectionString);
            builder.EnableSensitiveDataLogging();
            base.OnConfiguring(builder);
        }

        public IQueryable<User> GetUsers() => Users;
        public IQueryable<Producer> GetProducers() => Producers;
        public IQueryable<Category> GetCategories() => Categories;
        public IQueryable<Image> GetImages() => Images;
        public IQueryable<Item> GetItems() => Items;
        public IQueryable<Post> GetPosts() => Posts;

        protected DbSet<Category> Categories { get; set; }
        protected DbSet<Item> Items { get; set; }
        protected DbSet<Producer> Producers { get; set; }
        protected DbSet<Image> Images { get; set; }
        protected DbSet<Post> Posts { get; set; }
        protected DbSet<User> Users { get; set; }
    }
}
