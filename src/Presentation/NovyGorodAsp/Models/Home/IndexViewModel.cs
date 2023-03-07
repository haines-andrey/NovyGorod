using System.Collections.Generic;
using NovyGorod.Application.Contracts.Posts.Dto;
using NovyGorodAsp.Models.Shared;

namespace NovyGorodAsp.Models.Home;

public class IndexViewModel
{
    public IReadOnlyCollection<PostListDto> LastProjects { get; init; }

    public IReadOnlyCollection<PostListDto> LastTheatrePosts { get; init; }

    public IReadOnlyCollection<PostListDto> LastSchoolPosts { get; init; }

    public PostListContainerViewModel LastProjectsContainer => new() { Posts = LastProjects };

    public PostListContainerViewModel LastTheatrePostsContainer => new() { Posts = LastTheatrePosts };

    public PostListContainerViewModel LastSchoolPostsContainer => new() { Posts = LastSchoolPosts };
}