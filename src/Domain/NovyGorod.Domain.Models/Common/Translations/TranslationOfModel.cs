using System;

namespace NovyGorod.Domain.Models.Common.Translations;

public abstract class TranslationOfModel<TModel, TModelId, TTranslationId> : IHasId<TTranslationId>
    where TModel : IHasId<TModelId>
    where TModelId : IEquatable<TModelId>
    where TTranslationId : IEquatable<TTranslationId>
{
    public virtual TTranslationId Id { get; set; }

    public virtual TModel Model { get; set; }

    public virtual Language Language { get; set; }
}