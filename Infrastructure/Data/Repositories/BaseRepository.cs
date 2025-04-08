using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace Infrastructure.Data.Repositories;

public abstract class BaseRepository<TEntity, TModel> where TEntity : class
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<TEntity> _table;
    protected readonly IMemoryCache _cache;
    protected readonly string _cacheKey;

    protected BaseRepository(AppDbContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;

        _table = context.Set<TEntity>();
        _cacheKey = $"{typeof(TEntity).Name}_All";
    }

    public virtual async Task<RepositoryResult> AddAsync(TEntity entity)
    {
        if (entity == null)
            return new RepositoryResult { Succeeded = false, StatusCode = 400 };

        try
        {
            _table.Add(entity);
            await _context.SaveChangesAsync();

            return new RepositoryResult { Succeeded = true, StatusCode = 201 };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);

            return new RepositoryResult { Succeeded = false, StatusCode = 500, ErrorMessage = ex.Message };
        }
    }

    public virtual async Task<RepositoryResult> UpdateAsync(TEntity entity)
    {
        if (entity == null)
            return new RepositoryResult { Succeeded = false, StatusCode = 400 };

        try
        {
            _table.Update(entity);
            await _context.SaveChangesAsync();

            return new RepositoryResult { Succeeded = true, StatusCode = 200 };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);

            return new RepositoryResult { Succeeded = false, StatusCode = 500, ErrorMessage = ex.Message };
        }
    }

    public virtual async Task<RepositoryResult> DeleteAsync(TEntity entity)
    {
        if (entity == null)
            return new RepositoryResult { Succeeded = false, StatusCode = 400 };

        try
        {
            _table.Remove(entity);
            await _context.SaveChangesAsync();

            return new RepositoryResult { Succeeded = true, StatusCode = 200 };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);

            return new RepositoryResult { StatusCode = 500, Succeeded = false, ErrorMessage = ex.Message };
        }
    }

}
