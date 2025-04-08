using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

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
}
