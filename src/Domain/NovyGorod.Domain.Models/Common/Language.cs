using System.Diagnostics.CodeAnalysis;

namespace NovyGorod.Domain.Models.Common;

[ExcludeFromCodeCoverage]
public class Language : BaseEntity
{
    public string Code { get; set; }
}