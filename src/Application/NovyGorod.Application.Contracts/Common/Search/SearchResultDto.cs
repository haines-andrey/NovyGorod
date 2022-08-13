using System.Diagnostics.CodeAnalysis;

namespace NovyGorod.Application.Contracts.Common.Search;

[ExcludeFromCodeCoverage]
public record SearchResultDto<TDto>
{
    public IReadOnlyCollection<TDto> Items { get; init; }

    public PagingDto Paging { get; init; }
}