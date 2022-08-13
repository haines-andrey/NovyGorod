using NovyGorod.Application.Contracts.Common.Search;
using NovyGorod.Application.Contracts.Posts.Dto;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.Application.Contracts.Posts.Requests;

public record SearchPostsRequest : SearchRequest<PostListDto>
{
    public PostType Type { get; set; }
}