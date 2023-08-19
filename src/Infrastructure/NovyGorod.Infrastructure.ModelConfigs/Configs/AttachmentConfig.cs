﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovyGorod.Domain.Models.Attachments;

namespace NovyGorod.Infrastructure.ModelConfigs.Configs;

internal class AttachmentConfig : IEntityTypeConfiguration<Attachment>
{
    public void Configure(EntityTypeBuilder<Attachment> builder)
    {
        builder.ApplyBaseModelConfig()
            .ApplySequencedModelConfig()
            .ApplyTranslatedEntityConfig<Attachment, int, AttachmentTranslation>();

        builder.HasOne(x => x.Block).WithMany(x => x.Attachments)
            .IsRequired();
    }
}