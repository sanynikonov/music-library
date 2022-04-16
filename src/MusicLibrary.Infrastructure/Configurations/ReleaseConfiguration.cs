using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicLibrary.Domain.Entities.Releases;

namespace MusicLibrary.Infrastructure.Configurations;

public class ReleaseConfiguration : IEntityTypeConfiguration<Release>
{
    public void Configure(EntityTypeBuilder<Release> builder)
    {
        builder.Metadata.FindNavigation(nameof(Release.Artists))?
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Metadata.FindNavigation(nameof(Release.Songs))?
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.OwnsOne(p => p.Info);
    }
}