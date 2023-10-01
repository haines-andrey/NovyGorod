using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovyGorod.Domain.Models.Attachments;

namespace NovyGorod.Infrastructure.ModelConfigs.Configs;

internal class AttachmentConfig : EntityConfig<Attachment>
{
    public override void Configure(EntityTypeBuilder<Attachment> builder)
    {
        builder.ApplyBaseModelConfig()
            .ApplySequencedModelConfig();

        builder.HasOne(x => x.Block).WithMany(x => x.Attachments)
            .IsRequired();
    }
}