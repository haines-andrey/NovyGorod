using NovyGorod.Domain.ModelAccess.Queries;
using NovyGorod.Domain.Models.Common.Translations;

namespace NovyGorod.Domain.ModelAccess.Filters;

public static class Common
{
    public static QueryFilter<TModel> IdIs<TModel>(int id)
        where TModel : Models.Common.BaseModel
    {
        return QueryFilter<TModel>.Create(model => model.Id.Equals(id));
    }

    public static QueryFilter<TModel> IdIs<TModel, TId>(TId id)
        where TModel : Models.Common.IHasId<TId>
        where TId : IEquatable<TId>
    {
        return QueryFilter<TModel>.Create(model => model.Id.Equals(id));
    }

    public static QueryFilter<TModel> IdIsIn<TModel>(IEnumerable<int> ids)
        where TModel : Models.Common.BaseModel
    {
        var idsList = ids.Distinct().ToList();

        return QueryFilter<TModel>.Create(model => idsList.Contains(model.Id));
    }

    public static QueryFilter<TModel> IdIsIn<TModel, TId>(IEnumerable<TId> ids)
        where TModel : Models.Common.IHasId<TId>
        where TId : IEquatable<TId>
    {
        var idsList = ids.Distinct().ToList();

        return QueryFilter<TModel>.Create(model => idsList.Contains(model.Id));
    }

    public static QueryFilter<TModel> IsTranslatedInto<TModel, TModelId, TTranslation>(
        int languageId)
        where TModel : ITranslatedModel<TModel, TModelId, TTranslation>
        where TModelId : IEquatable<TModelId>
        where TTranslation : TranslationOfModel<TModel, TModelId, TranslationOfModelId<TModelId>>
    {
        return QueryFilter<TModel>.Create(
            model => model.Translations.Any(translation => translation.Id.LanguageId == languageId));
    }
    
    public static QueryFilter<TModel> IsTranslatedInto<TModel, TModelId, TTranslation>(
        IEnumerable<int> languageIds)
        where TModel : ITranslatedModel<TModel, TModelId, TTranslation>
        where TModelId : IEquatable<TModelId>
        where TTranslation : TranslationOfModel<TModel, TModelId, TranslationOfModelId<TModelId>>
    {
        var languagesIdsList = languageIds.Distinct().ToList();

        return QueryFilter<TModel>.Create(
            model => model.Translations.Any(translation => languagesIdsList.Contains(translation.Id.LanguageId)));
    }
}