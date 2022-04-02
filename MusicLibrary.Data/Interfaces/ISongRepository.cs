using System.Linq.Expressions;

namespace MusicLibrary.Data;

public interface ISongRepository : IRepository<Song>
{
    Task<IEnumerable<Song>> GetAllSongsWithAuthorsAsync(Expression<Func<Song, bool>> predicate = null,
        int? pageNumber = null, int? pageSize = null);
}