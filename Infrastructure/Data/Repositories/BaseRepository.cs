using Infrastructure.Common;
using Infrastructure.Data.Contexts;
using Infrastructure.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Data.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<TEntity> _table;

    protected BaseRepository(AppDbContext context)
    {
        _context = context;
        _table = context.Set<TEntity>();
    }

    public virtual async Task<OperationResult> ExistsAsync(Expression<Func<TEntity, bool>> filterByExpression)
    {
        try
        {
            var result = await _table.AnyAsync(filterByExpression);
            return result
                ? new OperationResult { Succeeded = true, StatusCode = 200 }
                : new OperationResult { Succeeded = false, StatusCode = 404 };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return new OperationResult { Succeeded = false, StatusCode = 500, ErrorMessage = ex.Message };
        }
    }

    public virtual async Task<OperationResult> AddAsync(TEntity entity)
    {
        if (entity == null)
            return new OperationResult { Succeeded = false, StatusCode = 400 };

        try
        {
            _table.Add(entity);
            await _context.SaveChangesAsync();

            return new OperationResult { Succeeded = true, StatusCode = 201 };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);

            return new OperationResult { Succeeded = false, StatusCode = 500, ErrorMessage = ex.Message };
        }
    }

    public virtual async Task<OperationResult> UpdateAsync(TEntity entity)
    {
        if (entity == null)
            return new OperationResult { Succeeded = false, StatusCode = 400 };

        try
        {
            _table.Update(entity);
            await _context.SaveChangesAsync();

            return new OperationResult { Succeeded = true, StatusCode = 200 };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);

            return new OperationResult { Succeeded = false, StatusCode = 500, ErrorMessage = ex.Message };
        }
    }

    public virtual async Task<OperationResult> DeleteAsync(TEntity entity)
    {
        if (entity == null)
            return new OperationResult { Succeeded = false, StatusCode = 400 };

        try
        {
            _table.Remove(entity);
            await _context.SaveChangesAsync();

            return new OperationResult { Succeeded = true, StatusCode = 200 };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);

            return new OperationResult { StatusCode = 500, Succeeded = false, ErrorMessage = ex.Message };
        }
    }

    public virtual async Task<OperationResult<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filterByExpression, params Expression<Func<TEntity, object>>[] includes)
    {
        try
        {
            IQueryable<TEntity> query = _table;

            if (includes != null && includes.Length > 0)
                foreach (var include in includes)
                    query = query.Include(include);

            var entity = await query.FirstOrDefaultAsync(filterByExpression);
            if (entity == null)
                return new OperationResult<TEntity> { Succeeded = false, StatusCode = 404 };

            return new OperationResult<TEntity> { Succeeded = true, StatusCode = 200, Result = entity };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return new OperationResult<TEntity> { Succeeded = false, StatusCode = 500, ErrorMessage = ex.Message };
        }
    }

    public virtual async Task<OperationResult<IEnumerable<TEntity>>> GetAllAsync(bool orderByDescending = false, Expression<Func<TEntity, object>>? sortByExpression = null,
        Expression<Func<TEntity, bool>>? filterByExpression = null, params Expression<Func<TEntity, object>>[] includes)
    {
        try
        {
            IQueryable<TEntity> query = _table;

            if (filterByExpression != null)
                query = query.Where(filterByExpression);

            if (includes != null && includes.Length > 0)
                foreach (var include in includes)
                    query = query.Include(include);

            if (sortByExpression != null)
                query = orderByDescending ? query.OrderByDescending(sortByExpression) : query.OrderBy(sortByExpression);

            var entities = await query.ToListAsync();
            return new OperationResult<IEnumerable<TEntity>> { Succeeded = true, StatusCode = 200, Result = entities };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);

            return new OperationResult<IEnumerable<TEntity>> { Succeeded = false, StatusCode = 500, ErrorMessage = ex.Message };
        }
    }

}
