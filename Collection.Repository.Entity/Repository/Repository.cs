using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Collection.Core.Repositories;
using Collection.Entity;
using Collection.Repository.Entity.DAL;
using Microsoft.EntityFrameworkCore;

namespace Collection.Repository.Entity.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly EntityDBContext _context;

        protected Repository()
        {
        }

        public Repository(EntityDBContext context)
        {
            _context = context;
        }

       public IQueryable<TEntity> List(bool readOnly = false)
        {
            if(readOnly)
                return _context.Set<TEntity>().AsNoTracking();
            else
                return _context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Search(string search)
        {
            return null;
        }


        public virtual TEntity GetById(int Id, bool readOnly)
        {
            return null;
        }

        public TEntity Insert(TEntity entity, bool forceSave = true)
        {
            var result = _context.Set<TEntity>().Add(entity);

            if (forceSave)
                _context.SaveChanges();

            return result.Entity;
        }

        public TEntity Update(TEntity entity, bool forceSave = true)
        {
            var result = _context.Set<TEntity>().Update(entity);

            if (forceSave)
                _context.SaveChanges();

            return result.Entity;
        }

        public void Delete(TEntity entity, bool forceSave = true)
        {
            _context.Set<TEntity>().Remove(entity);

            if (forceSave)
                _context.SaveChanges();
        }

    }
}