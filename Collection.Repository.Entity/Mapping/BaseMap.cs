using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Collection.Entity;

namespace Collection.Repository.Entity.Mapping
{
    public class BaseMap<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : class, IEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
        }
    }
}