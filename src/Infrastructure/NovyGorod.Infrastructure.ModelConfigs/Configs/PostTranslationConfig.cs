using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.Infrastructure.ModelConfigs.Configs;

internal class PostTranslationConfig : IEntityTypeConfiguration<PostTranslation>
{
    public void Configure(EntityTypeBuilder<PostTranslation> builder)
    {
        builder.ApplyBaseEntityConfig()
            .ApplyTranslationOfEntityConfig<Post, PostTranslation>();

        builder.HasOne(x => x.Preview).WithMany().HasForeignKey(x => x.PreviewId);
            
        builder.Property(x => x.Title).IsRequired();
    }
}