using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Domain.Entities.Releases;
using MusicLibrary.Domain.Entities.Songs;

namespace MusicLibrary.Infrastructure.Configurations;

public class ArtistItemConfiguration : IEntityTypeConfiguration<ArtistItem>
{
    public void Configure(EntityTypeBuilder<ArtistItem> builder)
    {
        builder.ToTable("Artists", "dbo");

        builder.HasMany<Song>()
            .WithMany(p => p.Artists)
            .UsingEntity("ArtistSongs");

        builder.HasMany<Release>()
            .WithMany(p => p.Artists)
            .UsingEntity("ArtistReleases");
    }
}