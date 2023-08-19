using System.Linq.Expressions;
using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Domain.ModelAccess.Queries;

public static partial class IQueryableExtensions
{
    public static Expression<Func<TModel, bool>> FilterById<TModel, TId>(int modelId)
        where TModel : IHasId<TId>
    {
        return model => model.Id.Equals(modelId);
    }

    public static Expression<Func<TModel, bool>> FilterByIds<TModel, TId>(IEnumerable<TId> modelIds)
        where TModel : IHasId<TId>
    {
        var modelIdsList = modelIds.Distinct().ToList();

        return model => modelIdsList.Contains(model.Id);
    }

    public static Expression<Func<TModel, bool>> FilterByLanguageId<TModel, TId, TTranslation>(int languageId)
        where TModel : ITranslatedModel<TModel, TId, TTranslation>
        where TTranslation : ITranslationOfModel<TModel, TId>
    {
        return model => model.Translations.Any(translation => translation.LanguageId == languageId);
    }
}