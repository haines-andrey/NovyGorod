using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Infrastructure.ModelConfigs;

public static class EntityTypeBuilderExtensions
{
    public static EntityTypeBuilder<TEntity> ApplyBaseModelConfig<TEntity>(
        this EntityTypeBuilder<TEntity> builder)
        where TEntity : BaseModel
    {
        builder.HasKey(x => x.Id);

        return builder;
    }

    public static EntityTypeBuilder<TEntity> ApplySequencedModelConfig<TEntity>(
        this EntityTypeBuilder<TEntity> builder)
        where TEntity : class, ISequencedModel
    {
        builder.Property(x => x.Index).IsRequired();

        return builder;
    }

    public static EntityTypeBuilder<TTranslation> ApplyTranslationOfModelConfig<TModel, TId, TTranslation>(
        this EntityTypeBuilder<TTranslation> builder)
        where TModel : class, IHasId<TId>
        where TTranslation : class, ITranslationOfModel<TModel, TId>
    {
        builder.HasOne(x => x.Language).WithMany()
            .HasForeignKey(x => x.LanguageId).IsRequired();

        builder.HasKey(x => new {x.ModelId, x.LanguageId});

        return builder;
    }

    public static EntityTypeBuilder<TModel> ApplyTranslatedEntityConfig<TModel, TId, TTranslation>(
        this EntityTypeBuilder<TModel> builder)
        where TModel : class, ITranslatedModel<TModel, TId, TTranslation>
        where TTranslation : class, ITranslationOfModel<TModel, TId>
    {
        builder.HasMany(x => x.Translations).WithOne(x => x.Model).HasForeignKey(x => x.ModelId);

        return builder;
    }
}