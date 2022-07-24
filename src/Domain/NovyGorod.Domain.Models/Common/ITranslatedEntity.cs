using System.Collections.Generic;

namespace NovyGorod.Domain.Models.Common;

public interface ITranslatedEntity<TEntity, TTranslation> : IBaseEntity
    where TEntity : IBaseEntity
    where TTranslation : ITranslationOfEntity<TEntity>
{
    ICollection<TTranslation> Translations { get; set; }
}