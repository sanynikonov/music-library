namespace MusicLibrary.Data.Entities;

public class Author : IBaseEntity
{
    public string Name { get; set; }
    public ICollection<SongsCollection> Albums { get; set; } = new List<SongsCollection>();
    public ICollection<Song> Songs { get; set; } = new List<Song>();
    public int Id { get; set; }
}