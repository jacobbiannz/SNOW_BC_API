using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using snow_bc_api.src.model;

namespace snow_bc_api.src.Repositories
{
   public interface IEntityRepository<T> where T : class, IEntity, new()
{
    IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
    IEnumerable<T> GetAll();
    int Count();
    Task<T> GetSingleAsync(int id);
    Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate);
    Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
    IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
    Task<int> DeleteWhereAsync(Expression<Func<T, bool>> predicate);
    Task<int> CommitAsync();
}
}
