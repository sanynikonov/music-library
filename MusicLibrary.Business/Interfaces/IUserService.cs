namespace MusicLibrary.Business;

public interface IUserService
{
    Task<UserPlaylistsModel> GetUserPlaylistsAsync(int userId);
    Task<UserProfileModel> GetUserProfileAsync(int userId);
}