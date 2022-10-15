using NovyGorod.Application.Contracts.Common.Search;
using NovyGorod.Application.Contracts.Posts.Requests;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorodAsp.Models.Shared;

public class PostListPaginationViewModel
{
    public PostType Type { get; init; }

    public PagingResultDto Paging { get; init; }

    public SearchPostsRequest PreviousPageRequest => new()
    {
        Type = Type,
        PageSize = Paging.PageSize,
        PageIndex = Paging.PageIndex - 1,
    };

    public SearchPostsRequest NextPageRequest => new()
    {
        Type = Type,
        PageSize = Paging.PageSize,
        PageIndex = Paging.PageIndex + 1,
    };

    public string GetPagesPointer(string template)
    {
        var currentPageIndex = Paging.TotalPages == default ? default : Paging.PageIndex + 1;

        return string.Format(template, currentPageIndex, Paging.TotalPages);
    }
}