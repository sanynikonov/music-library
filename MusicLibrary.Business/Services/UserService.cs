using AutoMapper;
using MusicLibrary.Business.Interfaces;
using MusicLibrary.Business.Models;
using MusicLibrary.Data.UnitOfWork;

namespace MusicLibrary.Business.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unit;

    public UserService(IUnitOfWork unit, IMapper mapper)
    {
        _unit = unit;
        _mapper = mapper;
    }

    public async Task<UserPlaylistsModel> GetUserPlaylistsAsync(int userId)
    {
        var user = await _unit.UserManager.FindByIdAsync(userId.ToString());

        if (user == null)
            return null;

        var playlists = await _unit.SongsCollectionsRepository.GetAllWithTypesAsync(c => c.UserAuthorId == userId);
        user.Playlists = playlists.ToArray();
        return _mapper.Map<UserPlaylistsModel>(user);
    }

    public async Task<UserProfileModel> GetUserProfileAsync(int userId)
    {
        var user = await _unit.UserManager.FindByIdAsync(userId.ToString());

        if (user == null)
            return null;

        return _mapper.Map<UserProfileModel>(user);
    }
}