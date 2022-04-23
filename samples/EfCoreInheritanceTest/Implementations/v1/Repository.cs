using System.Linq.Expressions;
using EfCoreInheritanceTest.Implementations.v1.Expressions;
using Microsoft.EntityFrameworkCore;

namespace EfCoreInheritanceTest.Implementations.v1;

public class Repository<T, TExtended> : IRepository<T> where TExtended : class, T
{
    private readonly AppDbContext _context;
    private readonly DbSet<TExtended> _dbSet;

    public Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TExtended>();
    }

    public async Task<T[]> Get(params Expression<Func<T, object>>[] includes)
    {
        IQueryable<TExtended> query = _dbSet;

        foreach (var expression in includes)
            query = query.Include(expression.ChangeType<T, TExtended>());

        T[] items = await _dbSet.ToArrayAsync();

        foreach (var item in items)
            if (item is INavigationPropertySynchronizer listener)
                listener.SynchronizeFromNavigationProperties();

        return items;
    }

    public async Task Add(T item)
    {
        if (item is INavigationPropertySynchronizer listener)
            listener.SynchronizeToNavigationProperties();
        await _context.AddAsync(item);
    }

    public async Task<int> Save()
    {
        return await _context.SaveChangesAsync();
    }
}