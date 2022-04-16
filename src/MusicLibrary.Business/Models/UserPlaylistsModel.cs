namespace MusicLibrary.Business.Models;

public class UserPlaylistsModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string ProfilePicturePath { get; set; }

    public IEnumerable<CollectionItem> Playlists { get; set; } = Enumerable.Empty<CollectionItem>();
}