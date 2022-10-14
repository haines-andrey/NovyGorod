using System.Collections.Generic;
using NovyGorod.Application.Contracts.Posts.Dto;
using NovyGorod.Application.Contracts.Posts.Requests;

namespace NovyGorodAsp.Models.Home;

public class IndexViewModel
{
    public IReadOnlyCollection<PostListDto> LastProjects { get; init; }

    public IReadOnlyCollection<PostListDto> LastTheatrePosts { get; init; }

    public IReadOnlyCollection<PostListDto> LastSchoolPosts { get; init; }

    
}