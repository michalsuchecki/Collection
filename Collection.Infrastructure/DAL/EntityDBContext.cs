using Microsoft.EntityFrameworkCore;
using Collection.Core.Domain;
using System.Linq;
using System;

namespace Collection.Infrastructure.DAL
{
    class EntityDBContext : DbContext, IDBContext
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

        public IQueryable<User> GetUsers()
        {
            return Users;
        }

        public IQueryable<Producer> GetProducers()
        {
            return Producers;
        }

        public IQueryable<Category> GetCategories()
        {
            return Categories;
        }

        public IQueryable<Image> GetImages()
        {
            return Images;
        }

        public IQueryable<Item> GetItems()
        {
            return Items;
        }

        public IQueryable<Post> GetPosts()
        {
            return Posts;
        }

        //public void UpdateEntity<T>(T entity) where T : class
        //{
        //    Update(entity);
        //}

        protected DbSet<Category> Categories { get; set; }
        protected DbSet<Item> Items { get; set; }
        protected DbSet<Producer> Producers { get; set; }
        protected DbSet<Image> Images { get; set; }
        protected DbSet<Post> Posts { get; set; }
        protected DbSet<User> Users { get; set; }
    }
}
