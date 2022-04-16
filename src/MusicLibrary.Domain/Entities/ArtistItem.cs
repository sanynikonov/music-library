using MusicLibrary.Domain.Common;

namespace MusicLibrary.Domain.Entities;

public class ArtistItem : BaseEntity, IAggregateRoot
{
    public string Name { get; private set; }

    public ArtistItem(string name)
    {
        Name = name;
    }
}