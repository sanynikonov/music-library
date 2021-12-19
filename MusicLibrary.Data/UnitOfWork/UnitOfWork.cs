using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MusicLibraryContext _context;
        private IServiceProvider _serviceProvider;

        private IRepository<Like> _likesRepository;
        private IRepository<Song> _songsRepository;
        private IRepository<SongsCollection> _songsCollectionsRepository;
        private IRepository<SongsCollectionType> _songsCollectionTypesRepository;
        private IRepository<Author> _authorsRepository;
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;
        private RoleManager<Role> _roleManager;

        public IRepository<Song> SongsRepository => _songsRepository ??= new EfRepository<Song>(_context);

        public IRepository<SongsCollection> SongsCollectionsRepository => _songsCollectionsRepository ??= new EfRepository<SongsCollection>(_context);

        public IRepository<SongsCollectionType> SongsCollectionTypesRepository => _songsCollectionTypesRepository ??= new EfRepository<SongsCollectionType>(_context);

        public IRepository<Like> LikesRepository => _likesRepository ??= new EfRepository<Like>(_context);

        public IRepository<Author> AuthorsRepository => _authorsRepository ??= new EfRepository<Author>(_context);

        public SignInManager<User> SignInManager => _signInManager ??= _serviceProvider.GetRequiredService<SignInManager<User>>();

        public UserManager<User> UserManager => _userManager ??= _serviceProvider.GetRequiredService<UserManager<User>>();

        public RoleManager<Role> RoleManager => _roleManager ??= _serviceProvider.GetRequiredService<RoleManager<Role>>();

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
