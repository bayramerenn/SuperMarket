using System.Linq.Expressions;

namespace SuperMarket.DataAccess.Repositories.Abstract
{
    public interface IRepository<T> where T : class, new()
    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        Task<T> GetByIdAsync(int id);

        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicates = null, params Expression<Func<T, object>>[] includeProperties);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}