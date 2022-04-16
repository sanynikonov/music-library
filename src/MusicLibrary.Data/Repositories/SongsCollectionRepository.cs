using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicLibrary.Data.Entities;
using MusicLibrary.Data.Interfaces;

namespace MusicLibrary.Data.Repositories;

public class SongsCollectionRepository : EfRepository<Collection>, ISongsCollectionRepository
{
    public SongsCollectionRepository(MusicLibraryContext dbContext) : base(dbContext)
    {
    }

    public async Task<Collection> GetWithArtistsAndSongsAsync(int id, CancellationToken cancellationToken)
    {
        return await DbContext.Collections
            .Include(c => c.Artist)
            .Include(c => c.Songs)
            .ThenInclude(s => s.Artists)
            .SingleOrDefaultAsync(c => c.Id == id, cancellationToken);
    }
}