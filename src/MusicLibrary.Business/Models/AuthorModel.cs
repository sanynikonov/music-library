namespace MusicLibrary.Business.Models;

public class AuthorModel
{
    public int Id { get; set; }
    public string Name { get; set; }

    public IEnumerable<SongsCollectionListItemModel> Albums { get; set; } =
        Enumerable.Empty<SongsCollectionListItemModel>();
    //TODO: display best songs
}