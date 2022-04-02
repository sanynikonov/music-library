using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicLibrary.Data.Entities;
using MusicLibrary.Data.Interfaces;

namespace MusicLibrary.Data.Repositories;

public class SongRepository : EfRepository<Song>, ISongRepository
{
    public SongRepository(MusicLibraryContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Song>> GetAllSongsWithAuthorsAsync(Expression<Func<Song, bool>> predicate = null,
        int? pageNumber = null, int? pageSize = null)
    {
        IQueryable<Song> query = DbContext.Songs;

        if (predicate != null) query = query.Where(predicate);

        if (pageNumber.HasValue && pageSize.HasValue)
            query = query.Skip((pageNumber.Value - 1) * pageSize.Value).Take(pageSize.Value);

        return await query
            .Include(p => p.Authors)
            .ToArrayAsync();
    }
}