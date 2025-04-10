using Infrastructure.Common;
using System.Linq.Expressions;

namespace Infrastructure.Data.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<OperationResult> AddAsync(TEntity entity);
        Task<OperationResult> DeleteAsync(TEntity entity);
        Task<OperationResult<IEnumerable<TEntity>>> GetAllAsync(bool orderByDescending = false, Expression<Func<TEntity, object>>? sortByExpression = null, Expression<Func<TEntity, bool>>? filterByExpression = null, params Expression<Func<TEntity, object>>[] includes);
        Task<OperationResult<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filterByExpression, params Expression<Func<TEntity, object>>[] includes);
        Task<OperationResult> UpdateAsync(TEntity entity);
    }
}