using NovyGorod.Application.Contracts.Posts.Requests;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorodAsp.Models.Shared;

public class NavBarViewModel
{
    private const int PageSize = 6;
    private const int PageIndex = 0;

    public SearchPostsRequest SearchProjectsRequest => new()
    {
        Type = PostType.Project, PageSize = PageSize, PageIndex = PageIndex
    };
    
    public SearchPostsRequest SearchTheatreRequest => new()
    {
        Type = PostType.Theatre, PageSize = PageSize, PageIndex = PageIndex
    };
    
    public SearchPostsRequest SearchSchoolRequest => new()
    {
        Type = PostType.School, PageSize = PageSize, PageIndex = PageIndex
    };
    
    public SearchPostsRequest SearchFestivalsRequest => new()
    {
        Type = PostType.Festival, PageSize = PageSize, PageIndex = PageIndex
    };
}