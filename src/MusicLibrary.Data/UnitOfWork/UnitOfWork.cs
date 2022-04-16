using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MusicLibrary.Data.Entities;
using MusicLibrary.Data.Interfaces;
using MusicLibrary.Data.Repositories;

namespace MusicLibrary.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly MusicLibraryContext _context;
    private readonly IServiceProvider _serviceProvider;

    private IAuthorRepository _authorsRepository;
    private IRepository<Like> _likesRepository;
    private ISongsCollectionRepository _songsCollectionsRepository;
    private ISongRepository _songsRepository;
    private RoleManager<Role> _roleManager;
    private SignInManager<User> _signInManager;
    private UserManager<User> _userManager;

    public UnitOfWork(MusicLibraryContext context, IServiceProvider serviceProvider)
    {
        _context = context;
        _serviceProvider = serviceProvider;
    }

    public ISongRepository SongsRepository => _songsRepository ??= new SongRepository(_context);

    public ISongsCollectionRepository SongsCollectionsRepository =>
        _songsCollectionsRepository ??= new SongsCollectionRepository(_context);

    public IRepository<Like> LikesRepository => _likesRepository ??= new EfRepository<Like>(_context);

    public IAuthorRepository AuthorsRepository => _authorsRepository ??= new AuthorRepository(_context);

    public SignInManager<User> SignInManager =>
        _signInManager ??= _serviceProvider.GetRequiredService<SignInManager<User>>();

    public UserManager<User> UserManager => _userManager ??= _serviceProvider.GetRequiredService<UserManager<User>>();

    public RoleManager<Role> RoleManager => _roleManager ??= _serviceProvider.GetRequiredService<RoleManager<Role>>();

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}