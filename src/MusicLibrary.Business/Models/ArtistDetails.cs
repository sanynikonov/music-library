namespace MusicLibrary.Business.Models;

public class ArtistDetails
{
    public int Id { get; set; }
    public string Name { get; set; }

    public IEnumerable<CollectionItem> Albums { get; set; } =
        Enumerable.Empty<CollectionItem>();
    //TODO: display best songs
}