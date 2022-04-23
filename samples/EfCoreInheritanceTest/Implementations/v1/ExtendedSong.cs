using EfCoreInheritanceTest.Entities;

namespace EfCoreInheritanceTest.Implementations.v1;

public class ExtendedSong : Song
{
    public ICollection<ExtendedPlaylist> Playlists { get; set; }
}