namespace NovyGorod.Domain.Models.Ids;

//ToDo: should be used when EF core will support keys for complex types
public record struct ModelId : IModelId
{
    public int Value { get; set; }

    public static ModelId Default = new();

    public object[] ConvertToValuesArray()
    {
        return new object[] {Value};
    }

    public bool Equals(IModelId other)
    {
        return other is ModelId modelId && modelId.Value == Value;
    }
}