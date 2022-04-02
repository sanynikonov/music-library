using Microsoft.AspNetCore.Identity;

namespace MusicLibrary.Data;

public interface IUnitOfWork
{
    public ISongRepository SongsRepository { get; }
    public ISongsCollectionRepository SongsCollectionsRepository { get; }
    public IRepository<SongsCollectionType> SongsCollectionTypesRepository { get; }
    public IRepository<Like> LikesRepository { get; }
    public IAuthorRepository AuthorsRepository { get; }
    public SignInManager<User> SignInManager { get; }
    public UserManager<User> UserManager { get; }
    public RoleManager<Role> RoleManager { get; }
    Task SaveChangesAsync();
}