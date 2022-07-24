using NovyGorod.Common.Extensions;
using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Domain.EntityAccess.Queries;

public class TranslatedEntityQueryParameters<TEntity, TTranslation> : BaseEntityQueryParameters<TEntity>
    where TEntity : IBaseEntity, ITranslatedEntity<TEntity, TTranslation>
    where TTranslation : ITranslationOfEntity<TEntity>
{
    public int? LanguageId { get; set; }
    public string LanguageCode { get; set; }

    protected override void AddFilters()
    {
        base.AddFilters();

        FilterIf(
            LanguageId.HasValue && LanguageCode.IsNullOrEmpty(),
            entity => entity.Translations.Any(translation => translation.LanguageId == LanguageId));

        FilterIf(
            !LanguageId.HasValue && !LanguageCode.IsNullOrEmpty(),
            entity => entity.Translations.Any(translation => translation.Language.Code == LanguageCode));
    }
}