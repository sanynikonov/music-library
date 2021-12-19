using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Data
{
    public class MusicLibraryContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongsCollection> SongsCollections { get; set; }
        public DbSet<SongsCollectionType> SongsCollectionTypes { get; set; }

        public MusicLibraryContext(DbContextOptions<MusicLibraryContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Author>()
                .HasMany(p => p.Albums)
                .WithMany(p => p.Authors);

            builder.Entity<Song>()
                .HasOne(p => p.Album)
                .WithMany(p => p.Songs);

            builder.Entity<Song>()
                .HasMany(p => p.Authors)
                .WithMany(p => p.Songs);

            builder.Entity<Song>()
                .HasMany(p => p.Playlists)
                .WithMany(p => p.PlaylistSongs)
                .UsingEntity<Dictionary<string, object>>(
                    "SongSongsCollection",
                    j => j.HasOne<SongsCollection>().WithMany().OnDelete(DeleteBehavior.Cascade),
                    j => j.HasOne<Song>().WithMany().OnDelete(DeleteBehavior.ClientCascade));

            builder.Entity<Song>()
                .HasMany(p => p.Likes)
                .WithOne(p => p.Song)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<User>()
                .HasMany(p => p.LikedSongs)
                .WithOne(p => p.User);

            builder.Entity<SongsCollection>()
                .HasMany(p => p.Users)
                .WithMany(p => p.SavedPlaylists)
                .UsingEntity<Dictionary<string, object>>(
                    "SongsCollectionUser",
                    j => j.HasOne<User>().WithMany().OnDelete(DeleteBehavior.Cascade),
                    j => j.HasOne<SongsCollection>().WithMany().OnDelete(DeleteBehavior.ClientCascade));

            builder.Entity<SongsCollection>()
                .HasOne(p => p.UserAuthor)
                .WithMany(p => p.Playlists);

            builder.Entity<SongsCollection>()
                .HasOne(p => p.SongsCollectionType)
                .WithMany(p => p.SongsCollections);
        }
    }
}
