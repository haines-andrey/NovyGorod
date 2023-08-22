using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovyGorod.Domain.Models.Attachments;

namespace NovyGorod.Infrastructure.ModelConfigs.Configs;

internal class AttachmentTranslationConfig : EntityConfig<AttachmentTranslation>
{
    public override void Configure(EntityTypeBuilder<AttachmentTranslation> builder)
    {
        builder.ApplyTranslationOfBaseModelConfig<Attachment, AttachmentTranslation>();

        builder.HasOne(x => x.SourceMedia).WithMany().HasForeignKey(x => x.SourceMediaId);
        builder.HasOne(x => x.PreviewMedia).WithMany().HasForeignKey(x => x.PreviewMediaId);
    }
}