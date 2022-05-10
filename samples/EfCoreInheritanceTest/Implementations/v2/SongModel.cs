using EfCoreInheritanceTest.Entities;

namespace EfCoreInheritanceTest.Implementations.v2;

public class SongModel : Song
{
    public ICollection<PlaylistModel> Playlists { get; set; } = new List<PlaylistModel>();
}