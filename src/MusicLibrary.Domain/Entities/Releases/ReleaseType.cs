using MusicLibrary.Domain.Common;

namespace MusicLibrary.Domain.Entities.Releases;

public class ReleaseType : BaseEntity
{
    public string Name { get; private set; }

    public ReleaseType(string name)
    {
        Name = name;
    }
}