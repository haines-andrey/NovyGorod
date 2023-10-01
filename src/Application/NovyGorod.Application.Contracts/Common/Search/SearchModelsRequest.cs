using MediatR;

namespace NovyGorod.Application.Contracts.Common.Search;

public record SearchModelsRequest<TModelDto> : IRequest<SearchModelsResultDto<TModelDto>>
{
    public int PageIndex { get; init; }

    public int PageSize { get; init; }
}