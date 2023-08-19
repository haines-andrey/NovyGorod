using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using NovyGorod.Application.Common.Extensions;
using NovyGorod.Application.Common.RequestHandlers;
using NovyGorod.Application.Contracts.Common.Search;
using NovyGorod.Domain.ModelAccess;
using NovyGorod.Domain.ModelAccess.Queries;
using NovyGorod.Domain.Services;

namespace NovyGorod.Application.Common.Search;

[ExcludeFromCodeCoverage]
public abstract class SearchRequestHandler<TRequest, TModel, TDto>
    : BaseRequestHandler<TRequest, SearchResultDto<TDto>>
    where TRequest : SearchRequest<TDto>
    where TModel : class
{
    private readonly IMapper _mapper;
    private readonly IReadOnlyRepository<TModel> _modelRepository;

    protected SearchRequestHandler(
        IExecutionContextService executionContextService,
        IMapper mapper,
        IReadOnlyRepository<TModel> modelRepository)
        : base(executionContextService)
    {
        _mapper = mapper;
        _modelRepository = modelRepository;
    }

    protected sealed override async Task<SearchResultDto<TDto>> HandleInternal(
        TRequest request,
        CancellationToken cancellationToken)
    {
        var query = CreateQuery(request);
        var result = await _modelRepository.Paginate(query, cancellationToken);

        var itemsDto = _mapper.MapWithTranslation<TDto[]>(result.Items, CurrentLanguageId);
        var pagingDto = _mapper.Map<PagingResultDto>(result.Paging);

        var resultDto = new SearchResultDto<TDto> {Items = itemsDto, Paging = pagingDto};

        return resultDto;
    }

    protected abstract IQuery<TModel> CreateQuery(TRequest request);
}