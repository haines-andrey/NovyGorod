using NovyGorod.Application.Contracts.Common;
using NovyGorod.Application.Contracts.Common.Search;
using NovyGorod.Application.Contracts.Posts.Dto;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.Application.Contracts.Posts.Requests;

public record SearchPostsRequest : SearchModelsRequest<PostListDto>, IHasLanguageId
{
    public PostType Type { get; init; }

    public int LanguageId { get; init; }
}