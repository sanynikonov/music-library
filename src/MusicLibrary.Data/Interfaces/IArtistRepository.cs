using MusicLibrary.Data.Entities;

namespace MusicLibrary.Data.Interfaces;

public interface IArtistRepository : IRepository<Artist>
{
    Task<Artist> GetWithAlbumsAsync(int id, CancellationToken cancellationToken = default);
}