using System.Collections.Generic;
using NovyGorod.Application.Contracts.Posts.Dto;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorodAsp.Models.Posts;

public class PostsViewModel
{
    public PostType Type { get; set; }
    public IReadOnlyCollection<PostListDto> Posts { get; set; }
}