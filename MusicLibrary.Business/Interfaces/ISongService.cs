namespace MusicLibrary.Business;

public interface ISongService
{
    Task<IEnumerable<SongModel>> GetAllSongsAsync(SearchFilterModel filter);
    Task<int> AddAsync(SongModel model);
    Task AddToPlaylistAsync(int songId, int playlistId);
    Task LikeAsync(int songId, int userId);
}