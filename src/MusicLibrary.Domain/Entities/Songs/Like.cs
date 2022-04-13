using MusicLibrary.Domain.Common;

namespace MusicLibrary.Domain.Entities.Songs;

public class Like : BaseEntity
{
    public int UserId { get; private set; }
    public Like(int userId)
    {
        UserId = userId;
    }
}