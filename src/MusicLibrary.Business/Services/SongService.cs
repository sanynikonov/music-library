using MusicLibrary.Business.Interfaces;
using MusicLibrary.Business.Models;
using MusicLibrary.Data.Entities;
using MusicLibrary.Data.UnitOfWork;

namespace MusicLibrary.Business.Services;

public class SongService : ISongService
{
    private readonly IUnitOfWork _unit;

    public SongService(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<IEnumerable<SongModel>> GetAllSongsAsync(SearchFilterModel filter)
    {
        var songs = await _unit.SongsRepository.GetAllSongsWithAuthorsAsync(s => s.Title.Contains(filter.SearchString),
            filter.PageNumber, filter.PageSize);
        var models = new List<SongModel>();
        foreach (var song in songs)
        {
            var songId = song.Id;
            models.Add(new SongModel
            {
                Title = song.Title,
                Id = song.Id,
                ReleaseId = song.ReleaseId,
                AudioPath = song.AudioPath,
                Artists = song.Artists.Select(a => new ArtistItem
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToArray(),
                LikesCount = await _unit.LikesRepository.CountAsync(l => songId == l.SongId)
            });
        }

        return models;
    }

    public async Task<int> AddAsync(SongModel model)
    {
        var song = new Song
        {
            Title = model.Title,
            ReleaseId = model.ReleaseId,
            AudioPath = model.AudioPath,
            Artists = model.Artists.Select(a => new Data.Entities.Artist {Name = a.Name}).ToArray()
        };

        await _unit.SongsRepository.AddAsync(song);
        await _unit.SaveChangesAsync();

        return song.Id;
    }

    public async Task AddToPlaylistAsync(int songId, int playlistId)
    {
        var playlist = await _unit.SongsCollectionsRepository.GetWithArtistsAndSongsAsync(playlistId);
        var song = await _unit.SongsRepository.GetAsync(songId);
        playlist.Songs.Add(song);

        await _unit.SongsCollectionsRepository.UpdateAsync(playlist);
        await _unit.SaveChangesAsync();
    }

    public async Task LikeAsync(int songId, int userId)
    {
        var like =
            (await _unit.LikesRepository.GetAsync(x => x.SongId == songId && x.UserId == userId)).FirstOrDefault();
        if (like == null)
            await _unit.LikesRepository.AddAsync(new Like {SongId = songId, UserId = userId});
        else
            await _unit.LikesRepository.DeleteAsync(like);

        await _unit.SaveChangesAsync();
    }
}