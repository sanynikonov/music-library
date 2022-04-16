namespace MusicLibrary.Data.Entities;

public class Like : IBaseEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int SongId { get; set; }
    public Song Song { get; set; }
}