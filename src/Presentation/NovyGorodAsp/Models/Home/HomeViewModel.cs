using System.Collections.Generic;
using NovyGorod.Application.Contracts.Posts.Dto;

namespace NovyGorodAsp.Models.Home;

public class HomeViewModel
{
    public IReadOnlyCollection<PostListDto> LastProjects { get; init; }

    public IReadOnlyCollection<PostListDto> LastTheatrePosts { get; init; }

    public IReadOnlyCollection<PostListDto> LastSchoolPosts { get; init; }
}