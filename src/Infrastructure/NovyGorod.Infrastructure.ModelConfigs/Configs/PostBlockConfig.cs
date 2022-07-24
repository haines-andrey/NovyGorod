using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.Infrastructure.ModelConfigs.Configs;

internal class PostBlockConfig : IEntityTypeConfiguration<PostBlock>
{
    public void Configure(EntityTypeBuilder<PostBlock> builder)
    {
        builder.ApplyBaseEntityConfig()
            .ApplyIndexedEntityConfig()
            .ApplyTranslatedEntityConfig<PostBlock, PostBlockTranslation>();

        builder.HasMany(x => x.Attachments).WithOne(x => x.Block)
            .HasForeignKey(x => x.BlockId).IsRequired();
    }
}