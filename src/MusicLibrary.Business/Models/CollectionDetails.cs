namespace MusicLibrary.Business.Models;

public class CollectionDetails
{
    public int Id { get; set; }
    public int Year { get; set; }
    public string Name { get; set; }
    public string SongsCollectionType { get; set; }
    public int UserAuthorId { get; set; }
    public IEnumerable<SongModel> Songs { get; set; } = Enumerable.Empty<SongModel>();
    public IEnumerable<AuthorItem> Authors { get; set; } = Enumerable.Empty<AuthorItem>();
}