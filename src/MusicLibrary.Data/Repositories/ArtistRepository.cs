using Microsoft.EntityFrameworkCore;
using MusicLibrary.Data.Entities;
using MusicLibrary.Data.Interfaces;

namespace MusicLibrary.Data.Repositories;

public class ArtistRepository : EfRepository<Artist>, IArtistRepository
{
    public ArtistRepository(MusicLibraryContext dbContext) : base(dbContext)
    {
    }

    public async Task<Artist> GetWithAlbumsAsync(int id, CancellationToken cancellationToken)
    {
        return await DbContext.Artists
            .Include(p => p.Releases)
            .ThenInclude(p => p.Type)
            .SingleOrDefaultAsync(a => a.Id == id, cancellationToken);
    }
}