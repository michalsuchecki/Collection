using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Collection.Models
{
    public class ToyContext : IdentityDbContext<User>
    {
        public ToyContext(DbContextOptions<ToyContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Toy> Toys { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Gallery> Gallery { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
