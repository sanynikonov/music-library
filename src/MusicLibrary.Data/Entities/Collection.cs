namespace MusicLibrary.Data.Entities;

public class Collection : IBaseEntity
{
    public int Id { get; set; }
    public string Title { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    #region Non-playlist stuff

    public int? Year { get; set; }
    public ReleaseType? Type { get; set; }
    public int? ArtistId { get; set; }
    public Artist Artist { get; set; }
    public ICollection<Song> Songs { get; set; } = new List<Song>();

    #endregion

    public ICollection<Song> PlaylistSongs { get; set; } = new List<Song>();
    public ICollection<User> Users { get; set; } = new List<User>();
}