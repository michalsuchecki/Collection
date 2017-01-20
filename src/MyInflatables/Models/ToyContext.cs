using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyInflatables.Models
{
    public class ToyContext : DbContext
    {
        public ToyContext(DbContextOptions<ToyContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Toy> Toys { get; set; }
    }
}
