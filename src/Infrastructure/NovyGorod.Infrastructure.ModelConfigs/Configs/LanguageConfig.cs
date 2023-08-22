using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Infrastructure.ModelConfigs.Configs;

public class LanguageConfig : EntityConfig<Language>
{
    public override void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.ApplyBaseModelConfig();
        builder.Property(x => x.Code).IsRequired();
        builder.HasIndex(x => x.Code).IsUnique();
    }
}