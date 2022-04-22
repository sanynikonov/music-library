namespace EfCoreInheritanceTest.Entities;

public class Playlist
{
    public int Id { get; set; }
    public string Title { get; set; }
    public ICollection<Song> Songs { get; set; } = new List<Song>();
}