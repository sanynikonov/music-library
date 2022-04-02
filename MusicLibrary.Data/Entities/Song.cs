namespace MusicLibrary.Data.Entities;

public class Song : IBaseEntity
{
    public string Name { get; set; }
    public string AudioPath { get; set; }
    public int AlbumId { get; set; }

    public SongsCollection Album { get; set; }
    public ICollection<Author> Authors { get; set; } = new List<Author>();
    public ICollection<SongsCollection> Playlists { get; set; } = new List<SongsCollection>();
    public ICollection<Like> Likes { get; set; } = new List<Like>();
    public int Id { get; set; }
}