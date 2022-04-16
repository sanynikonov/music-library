using MusicLibrary.Domain.Entities.Songs;

namespace MusicLibrary.Domain.Entities.Releases;

public class Release
{
    private readonly List<Song> _songs;
    private readonly List<ArtistItem> _artists;

    public CollectionInfo Info { get; private set; }
    public ReleaseType Type { get; private set; }

    public IReadOnlyList<Song> Songs => _songs;
    public IReadOnlyList<ArtistItem> Artists => _artists;

    protected Release(){}
    public Release(CollectionInfo info, ReleaseType type, List<Song> songs, List<ArtistItem> artists)
    {
        Info = info!;
        Type = type!;
        _songs = songs!;
        _artists = artists!;
    }
}