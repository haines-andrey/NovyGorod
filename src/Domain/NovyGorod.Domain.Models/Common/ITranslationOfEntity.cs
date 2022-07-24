namespace NovyGorod.Domain.Models.Common;

public interface ITranslationOfEntity<TEntity>
    where TEntity : IBaseEntity
{
    int LanguageId { get; set; }
        
    Language Language { get; set; }
        
    int EntityId { get; set; }
        
    TEntity Entity { get; set; }
}