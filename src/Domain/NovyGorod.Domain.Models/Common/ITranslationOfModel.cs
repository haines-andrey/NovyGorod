namespace NovyGorod.Domain.Models.Common;

public interface ITranslationOfModel<TModel, TId>
    where TModel : IHasId<TId>
{
    int LanguageId { get; set; }
        
    Language Language { get; set; }
        
    TId ModelId { get; set; }
        
    TModel Model { get; set; }
}