using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicLibrary.Data.Entities;

namespace MusicLibrary.Data;

public class MusicLibraryContext : IdentityDbContext<User, Role, int>
{
    public MusicLibraryContext(DbContextOptions<MusicLibraryContext> options) : base(options)
    {
        //Database.EnsureCreated();
    }

    public DbSet<Artist> Artists { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<Collection> Collections { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Artist>()
            .HasMany(p => p.Releases)
            .WithOne(p => p.Artist);

        builder.Entity<Song>()
            .HasOne(p => p.Release)
            .WithMany(p => p.Songs);

        builder.Entity<Song>()
            .HasMany(p => p.Artists)
            .WithMany(p => p.Songs);

        builder.Entity<Song>()
            .HasMany(p => p.Playlists)
            .WithMany(p => p.PlaylistSongs)
            .UsingEntity<Dictionary<string, object>>(
                "PlaylistSongs",
                j => j.HasOne<Collection>().WithMany().OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne<Song>().WithMany().OnDelete(DeleteBehavior.ClientCascade));

        builder.Entity<Song>()
            .HasMany(p => p.Likes)
            .WithOne(p => p.Song)
            .OnDelete(DeleteBehavior.ClientCascade);

        builder.Entity<User>()
            .HasMany(p => p.LikedSongs)
            .WithOne(p => p.User);

        builder.Entity<Collection>()
            .HasMany(p => p.Users)
            .WithMany(p => p.SavedPlaylists)
            .UsingEntity<Dictionary<string, object>>(
                "UserPlaylists",
                j => j.HasOne<User>().WithMany().OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne<Collection>().WithMany().OnDelete(DeleteBehavior.ClientCascade));

        builder.Entity<Collection>()
            .HasOne(p => p.User)
            .WithMany(p => p.Playlists);
    }
}