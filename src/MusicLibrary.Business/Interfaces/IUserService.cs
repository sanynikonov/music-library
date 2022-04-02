using MusicLibrary.Business.Models;

namespace MusicLibrary.Business.Interfaces;

public interface IUserService
{
    Task<UserPlaylistsModel> GetUserPlaylistsAsync(int userId);
    Task<UserProfileModel> GetUserProfileAsync(int userId);
}