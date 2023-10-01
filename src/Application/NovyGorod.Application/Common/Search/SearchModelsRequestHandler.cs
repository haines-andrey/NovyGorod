using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using NovyGorod.Application.Common.Extensions;
using NovyGorod.Application.Contracts.Common;
using NovyGorod.Application.Contracts.Common.Search;
using NovyGorod.Domain.ModelAccess;
using NovyGorod.Domain.ModelAccess.Queries.Builders;
using NovyGorod.Domain.ModelAccess.Queries.Results;

namespace NovyGorod.Application.Common.Search;

[ExcludeFromCodeCoverage]
public abstract class SearchModelsRequestHandler<TRequest, TModel, TModelDto>
    : IRequestHandler<TRequest, SearchModelsResultDto<TModelDto>>
    where TRequest : SearchModelsRequest<TModelDto>
    where TModel : class
{
    private readonly IMapper _mapper;
    private readonly IReadOnlyRepository<TModel> _modelRepository;

    protected SearchModelsRequestHandler(
        IMapper mapper,
        IReadOnlyRepository<TModel> modelRepository)
    {
        _mapper = mapper;
        _modelRepository = modelRepository;
    }

    public async Task<SearchModelsResultDto<TModelDto>> Handle(
        TRequest request,
        CancellationToken cancellationToken)
    {
        var query = GetQueryBuilder(request).Build();
        var pagination = await _modelRepository.Paginate(query, cancellationToken);
        var searchResultDto = CreateResultDto(pagination, request);

        return searchResultDto;
    }

    protected virtual IQueryBuilder<TModel> GetQueryBuilder(TRequest request)
    {
        return QueryBuilder<TModel>.CreateEmpty()
            .Skip(request.PageIndex * request.PageSize)
            .Take(request.PageSize);
    }

    private SearchModelsResultDto<TModelDto> CreateResultDto(Pagination<TModel> pagination, TRequest request)
    {
        IReadOnlyCollection<TModelDto> itemsDto;

        if (request is IHasLanguageId hasLanguageId)
        {
            itemsDto = _mapper.MapWithTranslation<TModelDto[]>(pagination.Items, hasLanguageId.LanguageId);
        }
        else
        {
            itemsDto = _mapper.Map<TModelDto[]>(pagination.Items);
        }

        var pagingDto = _mapper.Map<PagingResultDto>(pagination.Paging);

        return new SearchModelsResultDto<TModelDto> {Items = itemsDto, Paging = pagingDto};
    }
}