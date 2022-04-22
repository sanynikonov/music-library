using EfCoreInheritanceTest.DataModel;
using EfCoreInheritanceTest.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCoreInheritanceTest.DataAccess;

public class AppDbContext : DbContext
{
    public DbSet<ExtendedPlaylist> Playlists { get; set; }
    public DbSet<ExtendedSong> Songs { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExtendedSong>()
            .HasMany(p => p.Playlists)
            .WithMany(p => p.Songs)
            .UsingEntity("PlaylistSongs");

        modelBuilder.Ignore<Playlist>();
        modelBuilder.Ignore<Song>();

        base.OnModelCreating(modelBuilder);
    }
}