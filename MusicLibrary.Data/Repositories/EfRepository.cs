using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MusicLibrary.Data;

public class EfRepository<T> : IRepository<T> where T : class, IBaseEntity
{
    protected readonly MusicLibraryContext _dbContext;

    public EfRepository(MusicLibraryContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T> GetAsync(int id)
    {
        return await _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);

        return entity;
    }

    public Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate = null, int? pageNumber = null,
        int? pageSize = null)
    {
        var query = CreateQuery(predicate, pageNumber, pageSize);

        return await query.ToListAsync();
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
    {
        IQueryable<T> query = _dbContext.Set<T>();

        if (predicate != null) query = query.Where(predicate);

        return await query.CountAsync();
    }

    protected IQueryable<T> CreateQuery(Expression<Func<T, bool>> predicate, int? pageNumber, int? pageSize)
    {
        IQueryable<T> query = _dbContext.Set<T>();

        if (predicate != null) query = query.Where(predicate);

        if (pageNumber.HasValue && pageSize.HasValue)
            query = query.Skip((pageNumber.Value - 1) * pageSize.Value).Take(pageSize.Value);

        return query;
    }
}