using Microsoft.EntityFrameworkCore;

namespace MusicLibrary.Data;

public class AuthorRepository : EfRepository<Author>, IAuthorRepository
{
    public AuthorRepository(MusicLibraryContext dbContext) : base(dbContext)
    {
    }

    public async Task<Author> GetAuthorWithAlbumsAsync(int id)
    {
        return await _dbContext.Authors
            .Include(p => p.Albums)
            .ThenInclude(p => p.SongsCollectionType)
            .SingleOrDefaultAsync(a => a.Id == id);
    }
}