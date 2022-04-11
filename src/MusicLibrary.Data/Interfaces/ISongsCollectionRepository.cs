using System.Linq.Expressions;
using MusicLibrary.Data.Entities;

namespace MusicLibrary.Data.Interfaces;

public interface ISongsCollectionRepository : IRepository<SongsCollection>
{
    Task<IEnumerable<SongsCollection>> GetAllWithTypesAsync(Expression<Func<SongsCollection, bool>> predicate = null,
        int? pageNumber = null, int? pageSize = null, CancellationToken cancellationToken = default);

    Task<SongsCollection> GetWithAuthorsAndSongsAndTypesAsync(int id, CancellationToken cancellationToken = default);
}