using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.Infrastructure.ModelConfigs.Configs;

internal class PostBlockTranslationConfig : IEntityTypeConfiguration<PostBlockTranslation>
{
    public void Configure(EntityTypeBuilder<PostBlockTranslation> builder)
    {
        builder.ApplyBaseEntityConfig()
            .ApplyTranslationOfEntityConfig<PostBlock, PostBlockTranslation>();
    }
}