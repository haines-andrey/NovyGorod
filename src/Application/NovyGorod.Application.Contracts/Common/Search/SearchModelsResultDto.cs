using System.Diagnostics.CodeAnalysis;

namespace NovyGorod.Application.Contracts.Common.Search;

[ExcludeFromCodeCoverage]
public record SearchModelsResultDto<TModelDto>
{
    public IReadOnlyCollection<TModelDto> Items { get; init; }

    public PagingResultDto Paging { get; init; }
}