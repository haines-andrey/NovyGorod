using System.Diagnostics.CodeAnalysis;

namespace NovyGorod.Domain.Models.Common;

[ExcludeFromCodeCoverage]
public class Language : BaseModel
{
    public string Code { get; set; }
}