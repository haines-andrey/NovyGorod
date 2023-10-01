using System;

namespace NovyGorod.Domain.Models.Common.Translations;

public record TranslationOfModelId<TModelId>
    where TModelId : IEquatable<TModelId>
{
    public int LanguageId { get; set; }

    public TModelId ModelId { get; set; }
}