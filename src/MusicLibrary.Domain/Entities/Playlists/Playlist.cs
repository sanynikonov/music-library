using MusicLibrary.Domain.Common;
using MusicLibrary.Domain.Entities.Songs;

namespace MusicLibrary.Domain.Entities.Playlists;

public class Playlist : BaseEntity, IAggregateRoot
{
    private readonly List<Song> _songs;

    public CollectionInfo Info { get; set; }
    public IReadOnlyList<Song> Songs => _songs;

    protected Playlist(){}
    public Playlist(CollectionInfo info, List<Song> songs = null)
    {
        Info = info!;
        _songs = songs ?? new List<Song>();
    }

    public void UpdateSong(Song song)
    {
        _songs.RemoveAll(s => s.Id == song.Id);
        _songs.Add(song);
    }

    public void DeleteSong(Song song)
    {
        _songs.Remove(song);
    }
}