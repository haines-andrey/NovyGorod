using System.Linq;

namespace NovyGorod.Domain.Models.Ids;

//ToDo: should be used when EF core will support keys for complex types
public record struct TranslationOfModelId<TModelId> : IModelId
    where TModelId : IModelId
{
    public ModelId LanguageId { get; set; }

    public TModelId ModelId { get; set; }

    public object[] ConvertToValuesArray()
    {
        return new object[] {LanguageId.Value}.Append(ModelId.ConvertToValuesArray()).ToArray();
    }

    public bool Equals(IModelId other)
    {
        return other is TranslationOfModelId<TModelId> translationId &&
               translationId.LanguageId.Equals(LanguageId) &&
               translationId.ModelId.Equals(ModelId);
    }
}