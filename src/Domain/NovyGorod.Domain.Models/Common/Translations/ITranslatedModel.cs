using System.Collections.Generic;

namespace NovyGorod.Domain.Models.Common.Translations;

public interface ITranslatedModel<TModel, TTranslation> : IHasId<int>
    where TModel : class, ITranslatedModel<TModel, TTranslation>
    where TTranslation : TranslationOfModel<TModel>
{
    ICollection<TTranslation> Translations { get; set; }
}