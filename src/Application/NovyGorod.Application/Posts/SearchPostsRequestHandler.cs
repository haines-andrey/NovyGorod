using AutoMapper;
using NovyGorod.Application.Common.Search;
using NovyGorod.Application.Contracts.Posts.Dto;
using NovyGorod.Application.Contracts.Posts.Requests;
using NovyGorod.Domain.ModelAccess;
using NovyGorod.Domain.ModelAccess.Queries.Builders;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.Application.Posts;

public class SearchPostsRequestHandler : SearchModelsRequestHandler<SearchPostsRequest, Post, PostListDto>
{
    public SearchPostsRequestHandler(
        IMapper mapper,
        IReadOnlyRepository<Post> modelRepository)
        : base(mapper, modelRepository)
    {
    }

    protected override IQueryBuilder<Post> GetQueryBuilder(SearchPostsRequest request)
    {
        return base.GetQueryBuilder(request)
            .Where(
                Filters.Post.TypeIs(request.Type) &
                Filters.Post.IsTranslatedInto(request.LanguageId))
            .Order(orderable => orderable.OrderByDesc(post => post.Index));
    }
}