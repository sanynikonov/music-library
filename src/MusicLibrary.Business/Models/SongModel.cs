namespace MusicLibrary.Business.Models;

public class SongModel
{
    public int Id { get; set; }
    public int LikesCount { get; set; }
    public string Title { get; set; }
    public string AudioPath { get; set; }
    public int ReleaseId { get; set; }
    public IEnumerable<ArtistItem> Artists { get; set; } = Enumerable.Empty<ArtistItem>();
}