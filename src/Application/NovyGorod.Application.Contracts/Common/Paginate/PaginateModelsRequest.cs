using MediatR;

namespace NovyGorod.Application.Contracts.Common.Paginate;

public record PaginateModelsRequest<TModelDto> : IRequest<ModelsPaginationDto<TModelDto>>
{
    public int PageIndex { get; init; }

    public int PageSize { get; init; }
}