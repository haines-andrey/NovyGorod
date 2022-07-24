using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Infrastructure.ModelConfigs;

public static class EntityTypeBuilderExtensions
{
    public static EntityTypeBuilder<TEntity> ApplyBaseEntityConfig<TEntity>(
        this EntityTypeBuilder<TEntity> builder)
        where TEntity : class, IBaseEntity
    {
        builder.HasKey(x => x.Id);

        return builder;
    }

    public static EntityTypeBuilder<TEntity> ApplyIndexedEntityConfig<TEntity>(
        this EntityTypeBuilder<TEntity> builder)
        where TEntity : class, IIndexedEntity
    {
        builder.Property(x => x.Index).IsRequired();

        return builder;
    }

    public static EntityTypeBuilder<TTranslation> ApplyTranslationOfEntityConfig<TEntity, TTranslation>(
        this EntityTypeBuilder<TTranslation> builder)
        where TEntity : class, IBaseEntity
        where TTranslation : class, ITranslationOfEntity<TEntity>
    {
        builder.HasOne(x => x.Language).WithMany()
            .HasForeignKey(x => x.LanguageId).IsRequired();

        builder.HasIndex(x => new {x.EntityId, x.LanguageId}).IsUnique();

        return builder;
    }

    public static EntityTypeBuilder<TEntity> ApplyTranslatedEntityConfig<TEntity, TTranslation>(
        this EntityTypeBuilder<TEntity> builder)
        where TEntity : class, ITranslatedEntity<TEntity, TTranslation>
        where TTranslation : class, ITranslationOfEntity<TEntity>
    {
        builder.HasMany(x => x.Translations).WithOne(x => x.Entity).HasForeignKey(x => x.EntityId);

        return builder;
    }
}