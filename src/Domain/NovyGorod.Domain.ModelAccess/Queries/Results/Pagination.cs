using System.Diagnostics.CodeAnalysis;

namespace NovyGorod.Domain.ModelAccess.Queries.Results;

[ExcludeFromCodeCoverage]
public sealed record Pagination<TData>
{
    public Paging Paging { get; set; }

    public IReadOnlyCollection<TData> Items { get; set; }
}
