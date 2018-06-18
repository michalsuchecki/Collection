using System.Linq;
using System.Threading.Tasks;
using Collection.Entity;

namespace Collection.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        Task<TEntity> GetById(bool readOnly = false);
        Task<IQueryable<TEntity>> List(bool readOnly = false);
        Task<TEntity> Insert(TEntity entity, bool forceSave = true);
        Task<TEntity> Update(TEntity entity, bool forceSave = true);
        Task Delete(TEntity entity, bool forceSave = true);
    }
}
