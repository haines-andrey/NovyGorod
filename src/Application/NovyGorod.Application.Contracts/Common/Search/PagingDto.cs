using System.Diagnostics.CodeAnalysis;

namespace NovyGorod.Application.Contracts.Common.Search;

[ExcludeFromCodeCoverage]
public record PagingDto
{
    public int Page { get; init; }

    public int PageSize { get; init; }

    public int TotalCount { get; init; }

    public int TotalPages { get; init; }

    public bool HasPreviousPage { get; init; }

    public bool HasNextPage { get; init; }
}