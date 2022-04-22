namespace EfCoreInheritanceTest;

public class PlaylistModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public ICollection<ExtendedSong> Songs { get; set; } = new List<ExtendedSong>();
}