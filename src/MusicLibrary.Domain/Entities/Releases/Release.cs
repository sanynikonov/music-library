using MusicLibrary.Domain.Entities.Songs;

namespace MusicLibrary.Domain.Entities.Releases;

public class Release
{
    private readonly List<SongItem> _songs;
    private readonly List<AuthorItem> _authors;

    public CollectionInfo Info { get; private set; }
    public ReleaseType Type { get; private set; }

    public IReadOnlyList<SongItem> Songs => _songs;
    public IReadOnlyList<AuthorItem> Authors => _authors;

    protected Release(){}
    public Release(CollectionInfo info, ReleaseType type, List<SongItem> songs, List<AuthorItem> authors)
    {
        Info = info!;
        Type = type!;
        _songs = songs!;
        _authors = authors!;
    }
}