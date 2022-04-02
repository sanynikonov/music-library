namespace MusicLibrary.Business.Models;

public class SongsCollectionModel
{
    public int Id { get; set; }
    public int Year { get; set; }
    public string Name { get; set; }
    public string SongsCollectionType { get; set; }
    public int UserAuthorId { get; set; }
    public IEnumerable<SongModel> Songs { get; set; } = Enumerable.Empty<SongModel>();
    public IEnumerable<AuthorListItemModel> Authors { get; set; } = Enumerable.Empty<AuthorListItemModel>();
}