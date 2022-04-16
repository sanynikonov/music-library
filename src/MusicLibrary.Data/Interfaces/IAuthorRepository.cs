using MusicLibrary.Data.Entities;

namespace MusicLibrary.Data.Interfaces;

public interface IAuthorRepository : IRepository<Artist>
{
    Task<Artist> GetAuthorWithAlbumsAsync(int id, CancellationToken cancellationToken = default);
}