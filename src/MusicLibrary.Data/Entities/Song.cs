namespace MusicLibrary.Data.Entities;

public class Song : IBaseEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string AudioPath { get; set; }

    public int ReleaseId { get; set; }
    public Collection Release { get; set; }
    public ICollection<Like> Likes { get; set; } = new List<Like>();
    public ICollection<Artist> Artists { get; set; } = new List<Artist>();

    public ICollection<Collection> Playlists { get; set; } = new List<Collection>();
}