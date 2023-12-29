using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.Infrastructure.ModelConfigs.Configs;

internal class PostTranslationConfig : EntityConfig<PostTranslation>
{
    public override void Configure(EntityTypeBuilder<PostTranslation> builder)
    {
        builder.ApplyTranslationOfModelConfig<PostTranslation, Post>();

        builder.HasOne(x => x.Preview).WithMany().HasForeignKey(x => x.PreviewId);
        builder.HasOne(x => x.Video).WithMany().HasForeignKey(x => x.VideoId).IsRequired(false);

        builder.Property(x => x.Title).IsRequired();
    }
}