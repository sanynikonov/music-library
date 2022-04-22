namespace EfCoreInheritanceTest;

public class ExtendedSong : Song
{
    public ICollection<ExtendedPlaylist> Playlists { get; set; }
}