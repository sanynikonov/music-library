using Microsoft.EntityFrameworkCore;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Domain.Entities.Playlists;
using MusicLibrary.Domain.Entities.Releases;
using MusicLibrary.Domain.Entities.Songs;

namespace MusicLibrary.Infrastructure;

public class MusicLibraryContext : DbContext
{
    public DbSet<ArtistItem> Authors { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<Release> Releases { get; set; }
    public DbSet<Playlist> Playlists { get; set; }
    public DbSet<Like> Likes { get; set; }

    public MusicLibraryContext(DbContextOptions<MusicLibraryContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MusicLibraryContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}