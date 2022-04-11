using System.Linq.Expressions;
using MusicLibrary.Data.Entities;

namespace MusicLibrary.Data.Interfaces;

public interface IRepository<T> where T : class, IBaseEntity
{
    Task<T> GetAsync(int id, CancellationToken cancellationToken = default);

    Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate = null, int? pageNumer = null,
        int? pageSize = null, CancellationToken cancellationToken = default);

    Task<int> CountAsync(Expression<Func<T, bool>> predicate = null, CancellationToken cancellationToken = default);
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
}