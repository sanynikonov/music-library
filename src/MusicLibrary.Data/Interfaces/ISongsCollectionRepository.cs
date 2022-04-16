using MusicLibrary.Data.Entities;

namespace MusicLibrary.Data.Interfaces;

public interface ISongsCollectionRepository : IRepository<Collection>
{
    Task<Collection> GetWithArtistsAndSongsAsync(int id, CancellationToken cancellationToken = default);
}