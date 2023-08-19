using System.Collections.Generic;

namespace NovyGorod.Domain.Models.Common;

public interface ITranslatedModel<TModel, TId, TTranslation> : IHasId<TId>
    where TModel : IHasId<TId>
    where TTranslation : ITranslationOfModel<TModel, TId>
{
    ICollection<TTranslation> Translations { get; set; }
}