using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using NovyGorod.Application.Common.Extensions;
using NovyGorod.Application.Contracts.Posts;
using NovyGorod.Application.Contracts.Posts.Dto;
using NovyGorod.Application.Contracts.Posts.Requests;
using NovyGorod.Domain.EntityAccess;
using NovyGorod.Domain.EntityAccess.Queries;
using NovyGorod.Domain.Models.Posts;
using NovyGorod.Domain.Services;

namespace NovyGorod.Application.Posts;

public class GetPostRequestHandler : IRequestHandler<GetPostRequest, PostDto>
{
    private readonly IEntityAccessService<Post> _entityAccessService;
    private readonly IExecutionContextService _executionContextService;
    private readonly IMapper _mapper;

    public GetPostRequestHandler(
        IEntityAccessService<Post> entityAccessService,
        IExecutionContextService executionContextService,
        IMapper mapper)
    {
        _entityAccessService = entityAccessService;
        _executionContextService = executionContextService;
        _mapper = mapper;
    }

    public async Task<PostDto> Handle(GetPostRequest request, CancellationToken cancellationToken)
    {
        var langId = await _executionContextService.GetCurrentLanguageId();
        var postQuery = new TranslatedEntityQueryParameters<Post, PostTranslation>
        {
            Id = request.Id,
            LanguageId = langId,
        };

        var post = await _entityAccessService.GetSingleOrDefault(postQuery);

        return _mapper.MapWithTranslation<PostDto>(post, langId);
    }
}