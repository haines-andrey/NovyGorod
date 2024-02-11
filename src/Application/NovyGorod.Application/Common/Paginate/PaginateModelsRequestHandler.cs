using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using NovyGorod.Application.Common.Extensions;
using NovyGorod.Application.Contracts.Common;
using NovyGorod.Application.Contracts.Common.Paginate;
using NovyGorod.Domain.ModelAccess;
using NovyGorod.Domain.ModelAccess.Queries.Builders;
using NovyGorod.Domain.ModelAccess.Queries.Results;

namespace NovyGorod.Application.Common.Paginate;

[ExcludeFromCodeCoverage]
public abstract class PaginateModelsRequestHandler<TRequest, TModel, TModelDto>
    : IRequestHandler<TRequest, ModelsPaginationDto<TModelDto>>
    where TRequest : PaginateModelsRequest<TModelDto>
    where TModel : class
{
    private readonly IMapper _mapper;
    private readonly IReadOnlyRepository<TModel> _modelRepository;

    protected PaginateModelsRequestHandler(
        IMapper mapper,
        IReadOnlyRepository<TModel> modelRepository)
    {
        _mapper = mapper;
        _modelRepository = modelRepository;
    }

    public async Task<ModelsPaginationDto<TModelDto>> Handle(
        TRequest request,
        CancellationToken cancellationToken)
    {
        var query = GetQueryBuilder(request).Build();
        var pagination = await _modelRepository.Paginate(query, cancellationToken);
        var paginationDto = MapToDto(pagination, request);

        return paginationDto;
    }

    protected virtual IQueryBuilder<TModel> GetQueryBuilder(TRequest request)
    {
        return QueryBuilder<TModel>.CreateNew()
            .Skip(request.PageIndex * request.PageSize)
            .Take(request.PageSize);
    }

    private ModelsPaginationDto<TModelDto> MapToDto(Pagination<TModel> pagination, TRequest request)
    {
        IReadOnlyCollection<TModelDto> itemsDto;

        if (request is IHasLanguageId hasLanguageId)
        {
            itemsDto = _mapper.MapWithTranslation<List<TModelDto>>(pagination.Items, hasLanguageId.LanguageId);
        }
        else
        {
            itemsDto = _mapper.Map<List<TModelDto>>(pagination.Items);
        }

        var pagingDto = _mapper.Map<PagingDto>(pagination.Paging);

        return new ModelsPaginationDto<TModelDto> {Items = itemsDto, Paging = pagingDto};
    }
}