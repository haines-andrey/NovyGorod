using NovyGorod.Domain.ModelAccess.Queries;
using NovyGorod.Domain.Models.Common;
using NovyGorod.Domain.Models.Common.Translations;

namespace NovyGorod.Domain.ModelAccess.Filters;

internal static class Common
{
    public static QueryFilter<TModel> IdIs<TModel>(int id)
        where TModel : IHasId<int>
    {
        return QueryFilter<TModel>.Create(model => model.Id.Equals(id));
    }

    public static QueryFilter<TModel> IdIsIn<TModel>(IEnumerable<int> ids)
        where TModel : IHasId<int>
    {
        var idsList = ids.Distinct().ToList();

        return QueryFilter<TModel>.Create(model => idsList.Contains(model.Id));
    }

    public static QueryFilter<TModel> IsTranslatedInto<TModel, TTranslation>(int languageId)
        where TModel : class, ITranslatedModel<TModel, TTranslation>
        where TTranslation : TranslationOfModel<TModel>
    {
        return QueryFilter<TModel>.Create(
            model => model.Translations.Any(translation => translation.LanguageId.Equals(languageId)));
    }

    public static QueryFilter<TModel> IsTranslatedInto<TModel, TTranslation>(
        IEnumerable<int> languageIds)
        where TModel : class, ITranslatedModel<TModel, TTranslation>
        where TTranslation : TranslationOfModel<TModel>
    {
        var languagesIdsList = languageIds.Distinct().ToList();

        return QueryFilter<TModel>.Create(
            model => model.Translations.Any(translation => languagesIdsList.Contains(translation.LanguageId)));
    }
}