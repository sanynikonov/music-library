namespace MusicLibrary.Data;

public class Like : IBaseEntity
{
    public int UserId { get; set; }
    public int SongId { get; set; }
    public User User { get; set; }
    public Song Song { get; set; }
    public int Id { get; set; }
}