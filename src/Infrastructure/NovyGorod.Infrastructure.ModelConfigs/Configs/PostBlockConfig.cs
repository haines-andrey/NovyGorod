using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.Infrastructure.ModelConfigs.Configs;

internal class PostBlockConfig : EntityConfig<PostBlock>
{
    public override void Configure(EntityTypeBuilder<PostBlock> builder)
    {
        builder.HasId()
            .ApplySequencedModelConfig();

        builder.HasMany(x => x.Attachments).WithOne(x => x.Block)
            .HasForeignKey(x => x.BlockId).IsRequired();
    }
}