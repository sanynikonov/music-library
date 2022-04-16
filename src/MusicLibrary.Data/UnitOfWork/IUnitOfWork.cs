using Microsoft.AspNetCore.Identity;
using MusicLibrary.Data.Entities;
using MusicLibrary.Data.Interfaces;

namespace MusicLibrary.Data.UnitOfWork;

public interface IUnitOfWork
{
    public ISongRepository SongsRepository { get; }
    public ICollectionRepository CollectionsRepository { get; }
    public IRepository<Like> LikesRepository { get; }
    public IArtistRepository ArtistsRepository { get; }
    public SignInManager<User> SignInManager { get; }
    public UserManager<User> UserManager { get; }
    public RoleManager<Role> RoleManager { get; }
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}