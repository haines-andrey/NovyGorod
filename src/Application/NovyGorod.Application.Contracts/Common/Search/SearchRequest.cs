using MediatR;

namespace NovyGorod.Application.Contracts.Common.Search;

public record SearchRequest<TDto> : IRequest<SearchResultDto<TDto>>
{
    public int PageIndex { get; init; }

    public int PageSize { get; init; }
}