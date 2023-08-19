using NovyGorod.Application.Contracts.Media.Dto;
using NovyGorod.Domain.Models.Common;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.Application.Contracts.Posts.Dto;

public record PostListDto : BaseModelDto
{
    public ICollection<PostType> Types { get; init; }

    public string Title { get; init; }
        
    public string Summary { get; init; }

    public MediaDataDto Preview { get; init; }
    
    public DateTimeOffset CreatedAt { get; init; }
}