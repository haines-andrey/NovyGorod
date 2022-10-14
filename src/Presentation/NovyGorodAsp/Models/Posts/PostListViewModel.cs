using NovyGorod.Application.Contracts.Common.Search;
using NovyGorod.Application.Contracts.Posts.Dto;
using NovyGorod.Domain.Models.Posts;
using NovyGorodAsp.Models.Shared;

namespace NovyGorodAsp.Models.Posts;

public class PostsListViewModel
{
    public PostType Type { get; init; }

    public SearchResultDto<PostListDto> SearchResult { get; init; }

    public PostListPaginationViewModel PaginationViewModel => new()
    {
        Type = Type,
        Paging = SearchResult.Paging,
    };

    public PostListContainerViewModel ContainerViewModel => new() {Posts = SearchResult.Items};
}