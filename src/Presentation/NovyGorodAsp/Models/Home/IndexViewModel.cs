using System.Collections.Generic;
using NovyGorod.Application.Contracts.Posts.Dto;
using NovyGorod.Application.Contracts.Posts.Requests;
using NovyGorod.Domain.Models.Posts;
using NovyGorodAsp.Models.Shared;

namespace NovyGorodAsp.Models.Home;

public class IndexViewModel
{
    private const int PageIndex = 0;
    private const int PageSize = 6;

    public IReadOnlyCollection<PostListDto> LastProjects { get; init; }

    public IReadOnlyCollection<PostListDto> LastTheatrePosts { get; init; }

    public IReadOnlyCollection<PostListDto> LastSchoolPosts { get; init; }

    public PostListContainerViewModel LastProjectsContainer => new() { Posts = LastProjects };

    public PostListContainerViewModel LastTheatrePostsContainer => new() { Posts = LastProjects };

    public PostListContainerViewModel LastSchoolPostsContainer => new() { Posts = LastProjects };

    public ContactsViewModel Contacts => new();

    public SearchPostsRequest SearchProjectsRequest => new()
    {
        Type = PostType.Project, PageIndex = PageIndex, PageSize = PageSize,
    };
    
    public SearchPostsRequest SearchTheatrePostsRequest => new()
    {
        Type = PostType.Theatre, PageIndex = PageIndex, PageSize = PageSize,
    };
    
    public SearchPostsRequest SearchSchoolPostsRequest => new()
    {
        Type = PostType.School, PageIndex = PageIndex, PageSize = PageSize,
    };
}