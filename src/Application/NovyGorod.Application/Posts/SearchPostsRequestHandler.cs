using AutoMapper;
using NovyGorod.Application.Common.Search;
using NovyGorod.Application.Contracts.Posts.Dto;
using NovyGorod.Application.Contracts.Posts.Requests;
using NovyGorod.Application.Posts.Queries;
using NovyGorod.Domain.EntityAccess;
using NovyGorod.Domain.EntityAccess.Queries;
using NovyGorod.Domain.Models.Posts;
using NovyGorod.Domain.Services;

namespace NovyGorod.Application.Posts;

public class SearchPostsRequestHandler : SearchRequestHandler<SearchPostsRequest, Post, PostListDto>
{
    public SearchPostsRequestHandler(
        IMapper mapper,
        IExecutionContextService executionContextService,
        IEntityAccessService<Post> entityAccessService)
        : base(executionContextService, mapper, entityAccessService)
    {
    }

    protected override IQueryParameters<Post> CreateQuery(SearchPostsRequest request)
    {
        return new PostListQueryParameters {Type = request.Type, LanguageId = CurrentLanguageId};
    }
}