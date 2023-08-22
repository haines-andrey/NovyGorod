using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using NovyGorod.Application.Common.Extensions;
using NovyGorod.Application.Common.RequestHandlers;
using NovyGorod.Application.Contracts.Posts.Dto;
using NovyGorod.Application.Contracts.Posts.Requests;
using NovyGorod.Domain.ModelAccess;
using NovyGorod.Domain.ModelAccess.Queries;
using NovyGorod.Domain.ModelAccess.Queries.Builders;
using NovyGorod.Domain.Models.Posts;
using NovyGorod.Domain.Services;

namespace NovyGorod.Application.Posts;

public class GetPostRequestHandler : BaseRequestHandler<GetPostRequest, PostDto>
{
    private readonly IReadOnlyRepository<Post> _repository;
    private readonly IMapper _mapper;

    public GetPostRequestHandler(
        IExecutionContextService executionContextService,
        IReadOnlyRepository<Post> repository,
        IMapper mapper)
        : base(executionContextService)
    {
        _repository = repository;
        _mapper = mapper;
    }

    protected override async Task<PostDto> HandleInternal(GetPostRequest request, CancellationToken cancellationToken)
    {
        var query = QueryBuilder<Post>
            .CreateWithFilter(
                post =>
                    post.Id == request.Id &&
                    post.Translations.Any(translation => translation.Id.LanguageId == CurrentLanguageId))
            .Build();

        var post = await _repository.GetSingle(query, cancellationToken);

        return _mapper.MapWithTranslation<PostDto>(post, CurrentLanguageId);
    }
}