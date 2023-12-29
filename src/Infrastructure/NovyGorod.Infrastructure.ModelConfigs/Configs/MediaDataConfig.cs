using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovyGorod.Domain.Models;

namespace NovyGorod.Infrastructure.ModelConfigs.Configs;

internal class MediaDataConfig : EntityConfig<MediaData>
{
    public override void Configure(EntityTypeBuilder<MediaData> builder)
    {
        builder.HasId();
        builder.Property(x => x.Type).IsRequired();
        builder.Property(x => x.Url).IsRequired();
        builder.HasIndex(x => x.Url).IsUnique();
        builder.Property(x => x.IsLocal).IsRequired();
    }
}