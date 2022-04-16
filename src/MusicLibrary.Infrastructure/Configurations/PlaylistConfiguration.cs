using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicLibrary.Domain.Entities.Playlists;

namespace MusicLibrary.Infrastructure.Configurations;

public class PlaylistConfiguration : IEntityTypeConfiguration<Playlist>
{
    public void Configure(EntityTypeBuilder<Playlist> builder)
    {
        builder.Metadata.FindNavigation(nameof(Playlist.Songs))?
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.OwnsOne(p => p.Info);
    }
}