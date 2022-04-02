using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MusicLibrary.Data;

public class SongsCollectionRepository : EfRepository<SongsCollection>, ISongsCollectionRepository
{
    public SongsCollectionRepository(MusicLibraryContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<SongsCollection>> GetAllWithTypesAsync(
        Expression<Func<SongsCollection, bool>> predicate = null, int? pageNumber = null, int? pageSize = null)
    {
        return await CreateQuery(predicate, pageNumber, pageSize)
            .Include(c => c.SongsCollectionType)
            .ToArrayAsync();
    }

    public async Task<SongsCollection> GetWithAuthorsAndSongsAndTypesAsync(int id)
    {
        return await _dbContext.SongsCollections
            .Include(c => c.Authors)
            .Include(c => c.SongsCollectionType)
            .Include(c => c.Songs)
            .ThenInclude(s => s.Authors)
            .SingleOrDefaultAsync(c => c.Id == id);
    }
}