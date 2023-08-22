using System;
using System.Collections.Generic;

namespace NovyGorod.Domain.Models.Common.Translations;

public interface ITranslatedModel<TModel, TModelId, TTranslation> : IHasId<TModelId>
    where TModel : ITranslatedModel<TModel, TModelId, TTranslation>
    where TModelId : IEquatable<TModelId>
    where TTranslation : TranslationOfModel<TModel, TModelId, TranslationOfModelId<TModelId>>
{
    ICollection<TTranslation> Translations { get; set; }
}