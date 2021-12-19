using MusicLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Business
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unit;

        public UserService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<UserPlaylistsModel> GetUserPlaylistsAsync(int userId)
        {
            var user = await _unit.UserManager.FindByIdAsync(userId.ToString());
            var playlists = await _unit.SongsCollectionsRepository.GetAllWithTypesAsync(c => c.UserAuthorId == userId);
            return new UserPlaylistsModel
            {
                Id = user.Id,
                Name = user.Name,
                ProfilePicturePath = user.ProfilePicturePath,
                UserName = user.UserName,
                Playlists = playlists.Select(x => new SongsCollectionListItemModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    SongsCollectionType = x.SongsCollectionType.Name,
                    Year = x.Year
                })
            };
        }

        public async Task<UserProfileModel> GetUserProfileAsync(int userId)
        {
            var user = await _unit.UserManager.FindByIdAsync(userId.ToString());
            return new UserProfileModel
            {
                Id = user.Id,
                Bio = user.Bio,
                Email = user.Email,
                Name = user.Name,
                ProfilePicturePath = user.ProfilePicturePath,
                UserName = user.UserName
            };
        }
    }
}
