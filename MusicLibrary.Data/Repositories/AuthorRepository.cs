using Microsoft.EntityFrameworkCore;
using MusicLibrary.Data.Entities;
using MusicLibrary.Data.Interfaces;

namespace MusicLibrary.Data.Repositories;

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