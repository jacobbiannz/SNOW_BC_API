using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using snow_bc_api.src.model;
using snow_bc_api.src.data;
using System.Linq.Expressions;

namespace snow_bc_api.src.Repositories
{
    public class EntityRepository<T> : IEntityRepository<T>
    where T : class, IEntity, new()
    {
        private BcApiDbContext _context;

        #region Properties
        public EntityRepository(BcApiDbContext context)
        {
            _context = context;
        }
        #endregion
        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public virtual int Count()
        {
            return _context.Set<T>().Count();
        }
        public virtual IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsEnumerable();
        }

        public Task<T> GetSingleAsync(int id)
        {
            return _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.Where(predicate).FirstOrDefaultAsync();
        }

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            _context.Set<T>().Add(entity);
            await CommitAsync();
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
            await CommitAsync();
            return entity;
        }
        public virtual async Task<T> DeleteAsync(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
            await CommitAsync();
            return entity;
        }

        public virtual async Task<int> DeleteWhereAsync(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _context.Set<T>().Where(predicate);

            foreach (var entity in entities)
            {
                _context.Entry<T>(entity).State = EntityState.Deleted;
            }
            return await CommitAsync();
        }

        public virtual Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
