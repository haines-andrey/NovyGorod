using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.Infrastructure.ModelConfigs.Configs;

internal class PostBlockTranslationConfig : EntityConfig<PostBlockTranslation>
{
    public override void Configure(EntityTypeBuilder<PostBlockTranslation> builder)
    {
        builder.ApplyTranslationOfBaseModelConfig<PostBlock, PostBlockTranslation>();
    }
}