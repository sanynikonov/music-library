using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Business
{
    public interface IUserService
    {
        Task<UserPlaylistsModel> GetUserPlaylistsAsync(int userId);
        Task<UserProfileModel> GetUserProfileAsync(int userId);
    }
}
