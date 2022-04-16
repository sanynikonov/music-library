using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicLibrary.Domain.Entities.Songs;

namespace MusicLibrary.Infrastructure.Configurations;

public class SongConfiguration : IEntityTypeConfiguration<Song>
{
    public void Configure(EntityTypeBuilder<Song> builder)
    {
        builder.Metadata.FindNavigation(nameof(Song.Artists))?
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Metadata.FindNavigation(nameof(Song.Likes))?
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.OwnsOne(p => p.Info);

        builder.HasMany(p => p.Likes)
            .WithOne();
    }
}