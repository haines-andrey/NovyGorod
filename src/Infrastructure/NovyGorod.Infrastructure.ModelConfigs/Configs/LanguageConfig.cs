using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Infrastructure.ModelConfigs.Configs;

internal class LanguageConfig : EntityConfig<Language>
{
    public override void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.HasId();
        builder.Property(x => x.Code).IsRequired();
        builder.HasIndex(x => x.Code).IsUnique();
    }
}