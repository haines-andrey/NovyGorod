using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovyGorod.Domain.Models.Common;
using NovyGorod.Domain.Models.Common.Translations;

namespace NovyGorod.Infrastructure.ModelConfigs;

public static class EntityTypeBuilderExtensions
{
    public static EntityTypeBuilder<TEntity> ApplyBaseModelConfig<TEntity>(
        this EntityTypeBuilder<TEntity> builder)
        where TEntity : BaseModel
    {
        builder.HasKey(entity => entity.Id);

        return builder;
    }

    public static EntityTypeBuilder<TEntity> HasCompositeKey<TEntity, TId>(
        this EntityTypeBuilder<TEntity> builder,
        params string[] propertyNames)
        where TEntity : class, IHasId<TId>
        where TId : class, IEquatable<TId>
    {
        builder.OwnsOne(entity => entity.Id,
            ownedBuilder =>
            {
                foreach (var propertyName in propertyNames)
                {
                    ownedBuilder.Property(propertyName).HasColumnName(propertyName);
                }
            });

        builder.Navigation(entity => entity.Id).IsRequired();

        foreach (var propertyName in propertyNames)
        {
            builder.Property(propertyName).IsRequired().HasColumnName(propertyName);
        }

        builder.HasKey(propertyNames);

        return builder;
    }

    public static EntityTypeBuilder<TTranslation> ApplyTranslationOfBaseModelConfig<TModel, TTranslation>(
        this EntityTypeBuilder<TTranslation> builder)
        where TModel : BaseModel, ITranslatedModel<TModel, int, TTranslation>
        where TTranslation : TranslationOfBaseModel<TModel>
    {
        builder.HasCompositeKey<TTranslation, TranslationOfModelId<int>>(
            nameof(TranslationOfModelId<int>.ModelId),
            nameof(TranslationOfModelId<int>.LanguageId));
        
        builder
            .HasOne(translation => translation.Model)
            .WithMany(entity => entity.Translations)
            .HasForeignKey(nameof(TranslationOfModelId<int>.ModelId));

        builder
            .HasOne(translation => translation.Language)
            .WithMany()
            .HasForeignKey(nameof(TranslationOfModelId<int>.LanguageId));

        return builder;
    }

    public static EntityTypeBuilder<TEntity> ApplySequencedModelConfig<TEntity>(
        this EntityTypeBuilder<TEntity> builder)
        where TEntity : class, ISequencedModel
    {
        builder.Property(entity => entity.Index).IsRequired();
        builder.HasIndex(entity => entity.Index).IsDescending();

        return builder;
    }
}