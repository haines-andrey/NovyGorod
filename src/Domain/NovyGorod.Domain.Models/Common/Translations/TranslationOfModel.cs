
namespace NovyGorod.Domain.Models.Common.Translations;

public abstract class TranslationOfModel<TModel>
    where TModel : class, IHasId<int>
{
    public int LanguageId { get; set; }

    public int ModelId { get; set; }

    public virtual TModel Model { get; set; }

    public virtual Language Language { get; set; }
}