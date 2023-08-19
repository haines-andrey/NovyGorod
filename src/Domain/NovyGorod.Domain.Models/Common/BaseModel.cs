using System.Diagnostics.CodeAnalysis;

namespace NovyGorod.Domain.Models.Common;

[ExcludeFromCodeCoverage]
public abstract class BaseModel : IHasId<int>
{
    public int Id { get; set; }
}