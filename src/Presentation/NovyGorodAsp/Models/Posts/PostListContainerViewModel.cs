using System.Collections.Generic;
using NovyGorod.Application.Contracts.Posts.Dto;

namespace NovyGorodAsp.Models.Posts;

public class PostListContainerViewModel
{
    public IReadOnlyCollection<PostListDto> Posts { get; set; }
}