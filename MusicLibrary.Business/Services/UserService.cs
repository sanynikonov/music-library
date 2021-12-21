using AutoMapper;
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
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public async Task<UserPlaylistsModel> GetUserPlaylistsAsync(int userId)
        {
            var user = await _unit.UserManager.FindByIdAsync(userId.ToString());
            var playlists = await _unit.SongsCollectionsRepository.GetAllWithTypesAsync(c => c.UserAuthorId == userId);
            user.Playlists = playlists.ToArray();
            return _mapper.Map<UserPlaylistsModel>(user);
        }

        public async Task<UserProfileModel> GetUserProfileAsync(int userId)
        {
            var user = await _unit.UserManager.FindByIdAsync(userId.ToString());
            return _mapper.Map<UserProfileModel>(user);
        }
    }
}
