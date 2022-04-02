using System.Linq.Expressions;
using MusicLibrary.Data.Entities;

namespace MusicLibrary.Data.Interfaces;

public interface ISongRepository : IRepository<Song>
{
    Task<IEnumerable<Song>> GetAllSongsWithAuthorsAsync(Expression<Func<Song, bool>> predicate = null,
        int? pageNumber = null, int? pageSize = null);
}