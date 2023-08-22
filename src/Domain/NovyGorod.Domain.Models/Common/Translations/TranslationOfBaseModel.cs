namespace NovyGorod.Domain.Models.Common.Translations;

public abstract class TranslationOfBaseModel<TModel> : TranslationOfModel<TModel, int, TranslationOfModelId<int>>
    where TModel : IHasId<int>
{
}