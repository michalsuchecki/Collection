using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

using Collection.Repository.Entity.Mapping;

namespace Collection.Repository.Entity.DAL
{
    public class EntityDBContext : DbContext
    {
        private readonly string _connectionString;

        public EntityDBContext()
        {
            _connectionString = @"Server=(localdb)\Sandbox;Database=Collection_2_0;Trusted_Connection=True;MultipleActiveResultSets=true";
        }
        public EntityDBContext(DbContextOptions<EntityDBContext> options) : this(options, @"Server=(localdb)\Sandbox;Database=Collection_2_0;Trusted_Connection=True;MultipleActiveResultSets=true")
        {
        }

        public EntityDBContext(DbContextOptions<EntityDBContext> options, string connectionString) : base(options)
        {
            _connectionString = connectionString;
            Database.EnsureCreated();
        }

        protected override void  OnModelCreating(ModelBuilder builder)
        {
            // Common
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new ProducerMap());

            // Items
            builder.ApplyConfiguration(new ItemConditionMap());
            builder.ApplyConfiguration(new ItemDescriptionMap());
            builder.ApplyConfiguration(new ItemImageMap());
            builder.ApplyConfiguration(new ItemRarityMap());
            builder.ApplyConfiguration(new ItemStateMap());
            builder.ApplyConfiguration(new ItemMap());

            // User
            builder.ApplyConfiguration(new UserItemMap());
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new UserRoleMap());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(_connectionString);
            builder.EnableSensitiveDataLogging();

            base.OnConfiguring(builder);
        }
    }
}
