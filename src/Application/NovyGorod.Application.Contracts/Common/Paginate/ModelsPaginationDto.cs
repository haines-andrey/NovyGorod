using System.Diagnostics.CodeAnalysis;

namespace NovyGorod.Application.Contracts.Common.Paginate;

[ExcludeFromCodeCoverage]
public record ModelsPaginationDto<TModelDto>
{
    public PagingDto Paging { get; init; }

    public IReadOnlyCollection<TModelDto> Items { get; init; }
}