using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using NovyGorod.Application.Common.Extensions;
using NovyGorod.Application.Common.RequestHandlers;
using NovyGorod.Application.Contracts.Posts.Dto;
using NovyGorod.Application.Contracts.Posts.Requests;
using NovyGorod.Domain.EntityAccess;
using NovyGorod.Domain.EntityAccess.Queries;
using NovyGorod.Domain.Models.Posts;
using NovyGorod.Domain.Services;

namespace NovyGorod.Application.Posts;

public class GetPostRequestHandler : BaseRequestHandler<GetPostRequest, PostDto>
{
    private readonly IEntityAccessService<Post> _entityAccessService;
    private readonly IMapper _mapper;

    public GetPostRequestHandler(
        IExecutionContextService executionContextService,
        IEntityAccessService<Post> entityAccessService,
        IMapper mapper) : base(executionContextService)
    {
        _entityAccessService = entityAccessService;
        _mapper = mapper;
    }

    protected override async Task<PostDto> HandleInternal(GetPostRequest request, CancellationToken cancellationToken)
    {
        var query = new TranslatedEntityQueryParameters<Post, PostTranslation>
        {
            EntityId = request.Id,
            LanguageId = CurrentLanguageId,
        };

        var post = await _entityAccessService.GetSingleOrDefault(query);

        return _mapper.MapWithTranslation<PostDto>(post, CurrentLanguageId);
    }
}