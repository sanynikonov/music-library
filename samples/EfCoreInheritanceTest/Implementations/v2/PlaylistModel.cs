using EfCoreInheritanceTest.Entities;

namespace EfCoreInheritanceTest.Implementations.v2;

public class PlaylistModel : Playlist
{
    public ICollection<SongModel> SongModels
    {
        get => Songs.All(s => s is SongModel)
            ? Songs.Cast<SongModel>().ToList()
            : Songs.Select(s => s as SongModel ?? new SongModel { Id = s.Id, Title = s.Title }).ToList();
        set => Songs = value.Cast<Song>().ToList();
    }
}