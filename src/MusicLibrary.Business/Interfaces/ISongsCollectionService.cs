using MusicLibrary.Business.Models;

namespace MusicLibrary.Business.Interfaces;

public interface ISongsCollectionService
{
    Task<int> AddAsync(CollectionDetails details);
    Task LikeAsync(int collectionId, int userId);
}