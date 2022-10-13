using System.Diagnostics.CodeAnalysis;

namespace NovyGorod.Application.Contracts.Common.Search;

[ExcludeFromCodeCoverage]
public record PagingResultDto
{
    public int PageSize { get; init; }

    public int Total { get; init; }

    public int PageIndex { get; init; }

    public int TotalPages { get; init; }

    public bool HasPreviousPage { get; init; }

    public bool HasNextPage { get; init; }
}