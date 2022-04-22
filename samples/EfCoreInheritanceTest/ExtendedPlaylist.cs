namespace EfCoreInheritanceTest;

public class ExtendedPlaylist : Playlist, INavigationPropertySynchronizer
{
    public new ICollection<ExtendedSong> Songs { get; set; }
    public void SynchronizeFromNavigationProperties()
    {
        base.Songs = Songs.Cast<Song>().ToList();
    }

    public void SynchronizeToNavigationProperties()
    {
        Songs = base.Songs.Select(x => new ExtendedSong { Id = x.Id, Title = x.Title }).ToList();
    }
}

public interface INavigationPropertySynchronizer
{
    void SynchronizeFromNavigationProperties();
    void SynchronizeToNavigationProperties();
}