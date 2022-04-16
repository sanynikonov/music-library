using MusicLibrary.Business.Interfaces;
using MusicLibrary.Business.Models;
using MusicLibrary.Data.Entities;
using MusicLibrary.Data.UnitOfWork;

namespace MusicLibrary.Business.Services;

public class SongsCollectionService : ISongsCollectionService
{
    private readonly IUnitOfWork _unit;

    public SongsCollectionService(IUnitOfWork unit)
    {
        _unit = unit;
    }
    
    public async Task<int> AddAsync(CollectionDetails details)
    {
        var collection = new Collection
        {
            Title = details.Title,
            Year = details.Year,
            //Artists = details.Artists.Select(a => new Artist {Title = a.Title}).ToArray()
        };

        await _unit.CollectionsRepository.AddAsync(collection);
        await _unit.SaveChangesAsync();

        return collection.Id;
    }

    public async Task LikeAsync(int collectionId, int userId)
    {
        var collection = await _unit.CollectionsRepository.GetWithArtistsAndSongsAsync(userId);
        var songsIds = collection.Songs.Select(x => x.Id).ToArray();
        var likes = await _unit.LikesRepository.GetAsync(l => l.UserId == userId && songsIds.Contains(l.SongId));
        var unlikedSongs = songsIds.Except(likes.Select(x => x.SongId)).ToArray();
        foreach (var id in unlikedSongs) await _unit.LikesRepository.AddAsync(new Like {SongId = id, UserId = userId});
        await _unit.SaveChangesAsync();
    }
}