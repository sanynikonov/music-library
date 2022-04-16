namespace MusicLibrary.Business.Models;

public class CollectionDetails
{
    public int Id { get; set; }
    public int Year { get; set; }
    public string Title { get; set; }
    public string Type { get; set; }
    public int UserId { get; set; }
    public IEnumerable<SongModel> Songs { get; set; } = Enumerable.Empty<SongModel>();
    public IEnumerable<ArtistItem> Artists { get; set; } = Enumerable.Empty<ArtistItem>();
}