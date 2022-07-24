using System.Diagnostics.CodeAnalysis;

namespace NovyGorod.Domain.Models.Common;

[ExcludeFromCodeCoverage]
public class BaseEntity : IBaseEntity
{
    public int Id { get; set; }

    public bool IsNew => Id == default;
}