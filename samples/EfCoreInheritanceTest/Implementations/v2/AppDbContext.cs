using Microsoft.EntityFrameworkCore;

namespace EfCoreInheritanceTest.Implementations.v2;

public class AppDbContext : DbContext
{
    public DbSet<PlaylistModel> Playlists { get; set; }
    public DbSet<SongModel> Songs { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*modelBuilder.Entity<Song>()
            .HasMany<Playlist>()
            .WithMany(p => p.Songs)
            .UsingEntity<IDictionary<string, object>>(
                pt => pt.HasMany<Song>().WithOne().HasForeignKey(),
                pt => pt.HasOne<Playlist>().WithMany(p => p.Songs));*/

        modelBuilder.Entity<PlaylistModel>()
            .Ignore(p => p.Songs)
            .HasMany(p => p.SongModels)
            .WithMany(p => p.Playlists);

        base.OnModelCreating(modelBuilder);
    }
}