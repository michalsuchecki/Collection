using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Collection.Models
{
    public class ToyContext : DbContext
    {
        public ToyContext()
        {

        }
        public ToyContext(DbContextOptions<ToyContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Toy> Toys { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Gallery> Gallery { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // BUG: Overwrite value Status when adding toy to DB
            //modelBuilder.Entity<Toy>()
            //    .Property(o => o.Status)
            //    .HasDefaultValue(ToyStatus.AlreadyHave);

            base.OnModelCreating(modelBuilder);
        }
    }
}
