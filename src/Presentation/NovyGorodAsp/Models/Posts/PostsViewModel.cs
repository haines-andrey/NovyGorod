using NovyGorod.Application.Contracts.Common.Search;
using NovyGorod.Application.Contracts.Posts.Dto;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorodAsp.Models.Posts;

public class PostsViewModel
{
    public PostType Type { get; set; }

    public SearchResultDto<PostListDto> SearchResult { get; set; }
}