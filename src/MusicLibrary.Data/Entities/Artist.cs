namespace MusicLibrary.Data.Entities;

public class Artist : IBaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Song> Songs { get; set; } = new List<Song>();
    public ICollection<Collection> Releases { get; set; } = new List<Collection>();
}