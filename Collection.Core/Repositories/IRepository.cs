using System.Collections.Generic;
using System.Linq;
using Collection.Entity;

namespace Collection.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity GetById(int Id, bool readOnly = false);
        IQueryable<TEntity> List(bool readOnly = false);
        TEntity Insert(TEntity entity, bool forceSave = true);
        TEntity Update(TEntity entity, bool forceSave = true);
        void Delete(TEntity entity, bool forceSave = true);
        IQueryable<TEntity> Search(string search);
    }
}
