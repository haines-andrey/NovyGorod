using System.Collections.Generic;
using NovyGorod.Application.Contracts.Posts.Dto;

namespace NovyGorodAsp.Models.Shared;

public class PostListContainerViewModel
{
    public IReadOnlyCollection<PostListDto> Posts { get; init; }
}