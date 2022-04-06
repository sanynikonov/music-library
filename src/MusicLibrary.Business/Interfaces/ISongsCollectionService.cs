using MusicLibrary.Business.Models;

namespace MusicLibrary.Business.Interfaces;

public interface ISongsCollectionService
{
    Task<int> AddAsync(SongsCollectionModel model);
    Task LikeAsync(int collectionId, int userId);
}