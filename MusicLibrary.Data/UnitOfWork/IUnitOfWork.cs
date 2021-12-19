using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Data
{
    public interface IUnitOfWork
    {
        public IRepository<Song> SongsRepository { get; }
        public IRepository<SongsCollection> SongsCollectionsRepository { get; }
        public IRepository<SongsCollectionType> SongsCollectionTypesRepository { get; }
        public IRepository<Like> LikesRepository { get; }
        public IAuthorRepository AuthorsRepository { get; }
        public SignInManager<User> SignInManager { get; }
        public UserManager<User> UserManager { get; }
        public RoleManager<Role> RoleManager { get; }
        Task SaveChangesAsync();
    }
}
