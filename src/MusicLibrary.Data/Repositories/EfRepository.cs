using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicLibrary.Data.Entities;
using MusicLibrary.Data.Interfaces;

namespace MusicLibrary.Data.Repositories;

public class EfRepository<T> : IRepository<T> where T : class, IBaseEntity
{
    protected readonly MusicLibraryContext DbContext;

    public EfRepository(MusicLibraryContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<T> GetAsync(int id, CancellationToken cancellationToken)
    {
        return await DbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
    {
        await DbContext.Set<T>().AddAsync(entity, cancellationToken);

        return entity;
    }

    public Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        DbContext.Entry(entity).State = EntityState.Modified;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(T entity, CancellationToken cancellationToken)
    {
        DbContext.Set<T>().Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate = null, int? pageNumber = null,
        int? pageSize = null, CancellationToken cancellationToken = default)
    {
        var query = CreateQuery(predicate, pageNumber, pageSize);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null, CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = DbContext.Set<T>();

        if (predicate != null) query = query.Where(predicate);

        return await query.CountAsync(cancellationToken);
    }

    protected IQueryable<T> CreateQuery(Expression<Func<T, bool>> predicate, int? pageNumber, int? pageSize)
    {
        IQueryable<T> query = DbContext.Set<T>();

        if (predicate != null) query = query.Where(predicate);

        if (pageNumber.HasValue && pageSize.HasValue)
            query = query.Skip((pageNumber.Value - 1) * pageSize.Value).Take(pageSize.Value);

        return query;
    }
}