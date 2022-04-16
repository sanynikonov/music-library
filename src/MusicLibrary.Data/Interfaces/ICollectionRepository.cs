using MusicLibrary.Data.Entities;

namespace MusicLibrary.Data.Interfaces;

public interface ICollectionRepository : IRepository<Collection>
{
    Task<Collection> GetWithArtistsAndSongsAsync(int id, CancellationToken cancellationToken = default);
}