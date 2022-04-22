using EfCoreInheritanceTest.Entities;

namespace EfCoreInheritanceTest.DataModel;

public class ExtendedSong : Song
{
    public ICollection<ExtendedPlaylist> Playlists { get; set; }
}