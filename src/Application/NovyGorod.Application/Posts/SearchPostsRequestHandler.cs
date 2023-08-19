using System.Linq;
using AutoMapper;
using NovyGorod.Application.Common.Search;
using NovyGorod.Application.Contracts.Posts.Dto;
using NovyGorod.Application.Contracts.Posts.Requests;
using NovyGorod.Domain.ModelAccess;
using NovyGorod.Domain.ModelAccess.Queries;
using NovyGorod.Domain.ModelAccess.Queries.Builders;
using NovyGorod.Domain.Models.Posts;
using NovyGorod.Domain.Services;

namespace NovyGorod.Application.Posts;

public class SearchPostsRequestHandler : SearchRequestHandler<SearchPostsRequest, Post, PostListDto>
{
    public SearchPostsRequestHandler(
        IMapper mapper,
        IExecutionContextService executionContextService,
        IReadOnlyRepository<Post> modelRepository)
        : base(executionContextService, mapper, modelRepository)
    {
    }

    protected override IQuery<Post> CreateQuery(SearchPostsRequest request)
    {
        return QueryBuilder<Post>
            .CreateWithFilter(
                post => post.TypeLinks.Any(link => link.Type == request.Type) &&
                        post.Translations.Any(translation => translation.LanguageId == CurrentLanguageId))
            .Skip(request.PageIndex * request.PageSize)
            .Take(request.PageSize)
            .Build();
    }
}