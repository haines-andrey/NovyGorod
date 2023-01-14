using NovyGorod.Application.Contracts.Common.Search;
using NovyGorod.Application.Contracts.Posts.Requests;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorodAsp.Models.Shared;

public class PostListPaginationViewModel
{
    public PostType Type { get; init; }

    public PagingResultDto Paging { get; init; }
    
    public string ControllerActionName { get; init; }

    public int PreviousPageIndex => Paging.PageIndex;
    
    public int NextPageIndex => Paging.PageIndex + 2;

    public string GetPagesPointer(string template)
    {
        var currentPageIndex = Paging.TotalPages == default ? default : Paging.PageIndex + 1;

        return string.Format(template, currentPageIndex, Paging.TotalPages);
    }
}