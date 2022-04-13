namespace MusicLibrary.Domain;

public class Like : BaseEntity
{
    public int UserId { get; private set; }
    public Like(int userId)
    {
        UserId = userId;
    }
}