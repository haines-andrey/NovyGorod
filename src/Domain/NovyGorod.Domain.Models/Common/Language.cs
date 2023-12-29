using System.Diagnostics.CodeAnalysis;

namespace NovyGorod.Domain.Models.Common;

[ExcludeFromCodeCoverage]
public class Language : IHasId<int>
{
    public int Id { get; set; }

    public string Code { get; set; }
}