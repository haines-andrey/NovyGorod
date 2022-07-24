using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovyGorod.Domain.Models;

namespace NovyGorod.Infrastructure.ModelConfigs.Configs;

internal class MediaDataConfig : IEntityTypeConfiguration<MediaData>
{
    public void Configure(EntityTypeBuilder<MediaData> builder)
    {
        builder.ApplyBaseEntityConfig();
        builder.Property(x => x.Type).IsRequired();
        builder.Property(x => x.Url).IsRequired();
        builder.HasIndex(x => x.Url).IsUnique();
        builder.Property(x => x.IsLocal).IsRequired();
    }
}