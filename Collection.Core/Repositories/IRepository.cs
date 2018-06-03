using System.Linq;
using Collection.Core.Domain;

namespace Collection.Core.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        IQueryable<TEntity> List(bool readOnly = false);

        TEntity Insert(TEntity entity, bool forceSave = true);

        TEntity Update(TEntity entity, bool forceSave = true);
        
        void Delete(TEntity entity, bool forceSave = true);
    }
}
