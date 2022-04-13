namespace MusicLibrary.Domain.Entities.Songs;

public class SongInfo
{
    public string Title { get; private set; }
    public string AudioPath { get; private set; }
    public int AlbumId { get; private set; }

    public SongInfo(string title, string audioPath, int albumId)
    {
        Title = title;
        AudioPath = audioPath;
        AlbumId = albumId;
    }
}