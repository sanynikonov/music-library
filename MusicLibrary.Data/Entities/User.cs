using Microsoft.AspNetCore.Identity;

namespace MusicLibrary.Data;

public class User : IdentityUser<int>, IBaseEntity
{
    public string Name { get; set; }
    public string Bio { get; set; }
    public string ProfilePicturePath { get; set; }

    public ICollection<SongsCollection> Playlists { get; set; } = new List<SongsCollection>();
    public ICollection<SongsCollection> SavedPlaylists { get; set; } = new List<SongsCollection>();
    public ICollection<Like> LikedSongs { get; set; } = new List<Like>();
}