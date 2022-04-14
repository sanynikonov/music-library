using MusicLibrary.Domain.Common;

namespace MusicLibrary.Domain.Entities;

public class AuthorItem : BaseEntity
{
    public string Name { get; private set; }

    public AuthorItem(string name)
    {
        Name = name;
    }
}