using Infrastructure.Common;
using System.Linq.Expressions;

namespace Infrastructure.Data.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filterByExpression);
        Task<bool> AddAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filterByExpression, params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<TEntity>> GetAllAsync(bool orderByDescending = false, Expression<Func<TEntity, object>>? sortByExpression = null, Expression<Func<TEntity, bool>>? filterByExpression = null, params Expression<Func<TEntity, object>>[] includes);
    }
}