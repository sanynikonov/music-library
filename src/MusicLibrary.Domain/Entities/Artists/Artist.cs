using MusicLibrary.Domain.Common;
using MusicLibrary.Domain.Entities.Releases;

namespace MusicLibrary.Domain.Entities.Artists;

public class Artist : BaseEntity, IAggregateRoot
{
    private readonly List<Release> _releases = new();

    public string Name { get; private set; }
    public string LogoPath { get; private set; }
    public string Bio { get; private set; }

    public Artist()
    {

    }
}