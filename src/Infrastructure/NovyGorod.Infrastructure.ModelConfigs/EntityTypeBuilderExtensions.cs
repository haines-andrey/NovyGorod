using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovyGorod.Domain.Models.Common;
using NovyGorod.Domain.Models.Common.Translations;

namespace NovyGorod.Infrastructure.ModelConfigs;

internal static class EntityTypeBuilderExtensions
{
    public static EntityTypeBuilder<TEntity> HasId<TEntity>(
        this EntityTypeBuilder<TEntity> builder)
        where TEntity : class, IHasId<int>
    {
        builder.HasKey(entity => entity.Id);

        return builder;
    }

    public static EntityTypeBuilder<TTranslation> ApplyTranslationOfModelConfig<TTranslation, TModel>(
        this EntityTypeBuilder<TTranslation> builder)
        where TTranslation : TranslationOfModel<TModel>
        where TModel : class, ITranslatedModel<TModel, TTranslation>
    {
        builder
            .HasOne(translation => translation.Language)
            .WithMany()
            .HasForeignKey(translation => translation.LanguageId);

        builder
            .HasOne(translation => translation.Model)
            .WithMany(entity => entity.Translations)
            .HasForeignKey(translation => translation.ModelId);

        builder.HasKey(translation => new {translation.ModelId, translation.LanguageId});

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