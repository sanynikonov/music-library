using MusicLibrary.Domain.Common;
using MusicLibrary.Domain.Entities.Releases;

namespace MusicLibrary.Domain.Entities.Playlists;

public class Playlist : BaseEntity, IAggregateRoot
{
    private readonly List<SongItem> _songs;

    public CollectionInfo Info { get; set; }
    public IReadOnlyList<SongItem> Songs => _songs;

    protected Playlist(){}
    public Playlist(CollectionInfo info, List<SongItem> songs = null)
    {
        Info = info!;
        _songs = songs ?? new List<SongItem>();
    }

    public void UpdateSong(SongItem song)
    {
        _songs.RemoveAll(s => s.Id == song.Id);
        _songs.Add(song);
    }

    public void DeleteSong(SongItem song)
    {
        _songs.Remove(song);
    }
}