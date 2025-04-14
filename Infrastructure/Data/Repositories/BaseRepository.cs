using Infrastructure.Data.Contexts;
using Infrastructure.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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

    public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filterByExpression)
    {
        var result = await _table.AnyAsync(filterByExpression);
        return result;
    }

    public virtual async Task<bool> AddAsync(TEntity entity)
    {
        if (entity == null) return false;

        _table.Add(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public virtual async Task<bool> UpdateAsync(TEntity entity)
    {
        if (entity == null) return false;

        _table.Update(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public virtual async Task<bool> DeleteAsync(TEntity entity)
    {
        if (entity == null) return false;

        _table.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filterByExpression, params Expression<Func<TEntity, object>>[] includes)
    {

        IQueryable<TEntity> query = _table;

        if (includes != null && includes.Length > 0)
            foreach (var include in includes)
                query = query.Include(include);

        var entity = await query.FirstOrDefaultAsync(filterByExpression);
        return entity;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(bool orderByDescending = false, Expression<Func<TEntity, object>>? sortByExpression = null,
        Expression<Func<TEntity, bool>>? filterByExpression = null, params Expression<Func<TEntity, object>>[] includes)
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
        return entities;
    }

}
