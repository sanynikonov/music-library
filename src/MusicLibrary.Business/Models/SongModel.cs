namespace MusicLibrary.Business.Models;

public class SongModel
{
    public int Id { get; set; }
    public int LikesCount { get; set; }
    public string Name { get; set; }
    public string AudioPath { get; set; }
    public int AlbumId { get; set; }
    public IEnumerable<AuthorItem> Authors { get; set; } = Enumerable.Empty<AuthorItem>();
}