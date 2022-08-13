using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using NovyGorod.Application.Common.Extensions;
using NovyGorod.Application.Common.RequestHandlers;
using NovyGorod.Application.Contracts.Common.Search;
using NovyGorod.Domain.EntityAccess;
using NovyGorod.Domain.EntityAccess.Queries;
using NovyGorod.Domain.Services;

namespace NovyGorod.Application.Common.Search;

[ExcludeFromCodeCoverage]
public abstract class SearchRequestHandler<TRequest, TEntity, TDto>
    : BaseRequestHandler<TRequest, SearchResultDto<TDto>>
    where TRequest : SearchRequest<TDto>
{
    private readonly IMapper _mapper;
    private readonly IEntityAccessService<TEntity> _entityAccessService;

    protected SearchRequestHandler(
        IExecutionContextService executionContextService,
        IMapper mapper,
        IEntityAccessService<TEntity> entityAccessService)
        : base(executionContextService)
    {
        _mapper = mapper;
        _entityAccessService = entityAccessService;
    }

    protected sealed override async Task<SearchResultDto<TDto>> HandleInternal(
        TRequest request,
        CancellationToken cancellationToken)
    {
        var query = CreateQuery(request);
        var result = await _entityAccessService.GetAll(query);

        var itemsDto = _mapper.MapWithTranslation<TDto[]>(result.Items, CurrentLanguageId);
        var pagingDto = _mapper.Map<PagingDto>(result.Paging);

        var resultDto = new SearchResultDto<TDto> {Items = itemsDto, Paging = pagingDto};

        return resultDto;
    }

    protected abstract IQueryParameters<TEntity> CreateQuery(TRequest request);
}