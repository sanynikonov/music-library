using Microsoft.AspNetCore.Identity;

namespace MusicLibrary.Data.Entities;

public class User : IdentityUser<int>, IBaseEntity
{
    public string Name { get; set; }
    public string Bio { get; set; }
    public string ProfilePicturePath { get; set; }

    public ICollection<Collection> Playlists { get; set; } = new List<Collection>();
    public ICollection<Collection> SavedPlaylists { get; set; } = new List<Collection>();
    public ICollection<Like> LikedSongs { get; set; } = new List<Like>();
}