using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Domain.EntityAccess.Queries;

public class TranslatedEntityQueryParameters<TEntity, TTranslation> : BaseQueryParameters<TEntity>
    where TEntity : IBaseEntity, ITranslatedEntity<TEntity, TTranslation>
    where TTranslation : ITranslationOfEntity<TEntity>
{
    public int? EntityId { get; set; }

    public int LanguageId { get; set; }

    protected override void AddFilters()
    {
        FilterIf(EntityId.HasValue, entity => entity.Id == EntityId);
        Filter(entity => entity.Translations.Any(translation => translation.LanguageId == LanguageId));
    }
}